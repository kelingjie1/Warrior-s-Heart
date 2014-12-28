using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
public enum AttackState
{
    None,
    Attack,
}
public enum MoveState
{
    Idle,
    Move,
    KnockBack,
}

public class Warrior : MonoBehaviour
{
    public WarriorAttribute attribute = new WarriorAttribute();
    //属性
    public float knockback;
    public float antiKnockback;
    public float physicalAttack;
    public float physicalDefence;
    public float magicAttack;
    public float magicDefence;
    public float hitDelay;
    public float attackInterval;
    public float maxHP;
    public float maxMoveSpeed;
    public bool canAttackMove;
    public float guardingDistance;

    //当前属性
    public float hp;
    public float attackSpeed;
    public float acceleration;
    public float attackDistance;
    
    //状态
    public float hitRestTime;
    public float attackRestTime;
    public AttackState attackState;
    public MoveState moveState;
    public bool hasEnemyInAttackDistance;
    public OrderedList<BattleEventHandler> FindHitTargetHandler = new OrderedList<BattleEventHandler>();
    public OrderedList<BattleEventHandler> FinishAttackHandler = new OrderedList<BattleEventHandler>();
    public int dir
    {
        get
        {
            if (isAttacker)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
    public void ReadFromXML(XmlElement item)
    {
        name = item.Name;
        isAttacker = bool.Parse(item.GetAttribute("IsAttacker"));
        attribute.template = new WarriorTemplate(Config.WarriorPath + item.GetAttribute("WarriorTemplate"));
        transform.localPosition = new Vector3(int.Parse(item.GetAttribute("X")), BattleField.Instance.floorHeight, 0);
        attribute.powerPoint = int.Parse(item.GetAttribute("PowerPoint"));
        attribute.agilityPoint = int.Parse(item.GetAttribute("AgilityPoint"));
        attribute.strongPoint = int.Parse(item.GetAttribute("StrongPoint"));
        attribute.intelligencePoint = int.Parse(item.GetAttribute("IntelligencePoint"));

        guardingDistance = int.Parse(item.GetAttribute("GuardingDistance"));

        if (attribute.template.category.Equals("Fighter"))
        {
            knockback = 2f;
            maxMoveSpeed = 1.0f;
            acceleration = 1f;
            attackDistance = 100;
            hitDelay = 0.3f;
            attackInterval = 1;
            canAttackMove = true;

            this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
            DidFinishAttackHandler_Melee_Base didfinishattack = new DidFinishAttackHandler_Melee_Base();
            didfinishattack.owner = this;
            BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
        }
        else
        {
            knockback = 1f;
            maxMoveSpeed = 1.0f;
            acceleration = 1f;
            attackDistance = 700;
            hitDelay = 0.3f;
            attackInterval = 2;
            canAttackMove = false;

            this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
            DidFinishAttackHandler_Remote_Base didfinishattack = new DidFinishAttackHandler_Remote_Base();
            didfinishattack.owner = this;
            BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
        }


    }
    void UpdateAnimation()
    {
        
        UISpriteAnimation animation = this.GetComponent<UISpriteAnimation>();
        animation.framesPerSecond = 30;
        animation.enabled = true;
        animation.loop = true;
        string lastPrefix = animation.namePrefix;
        if (attackState==AttackState.Attack)
        {
            animation.namePrefix = "attack";
        }
        else
        {
            if (moveState==MoveState.Idle)
            {
                animation.namePrefix = "standby";
            }
            else if (moveState==MoveState.Move)
            {
                animation.namePrefix = "run";
            }
            else if (moveState == MoveState.KnockBack)
            {
                animation.namePrefix = "back";
            }
            else
            {
                Debug.LogError("error");
            }
        }
        if (lastPrefix!=animation.namePrefix)
        {
            animation.ResetToBeginning();
        }
    }
    public bool isAttacker;


    public static Warrior Create()
    {
        return ResourceManager.Load("Prefab/Game/Warrior").GetComponent<Warrior>();
    }

    public void TestMelee()
    {
        //近战
        knockback = 1f;
        maxMoveSpeed = 1.0f;
        acceleration = 1f;
        attackDistance = 100;
        hitDelay = 0.3f;
        attackInterval = 1;
        canAttackMove = true;
        this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
        DidFinishAttackHandler_Melee_Base didfinishattack = new DidFinishAttackHandler_Melee_Base();
        didfinishattack.owner = this;
        BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
    }
    public void TestRemote()
    {
        //远程
        knockback = 1f;
        maxMoveSpeed = 1.0f;
        acceleration = 1f;
        attackDistance = 700;
        hitDelay = 0.3f;
        attackInterval = 2;
        canAttackMove = false;
        this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
        DidFinishAttackHandler_Remote_Base didfinishattack = new DidFinishAttackHandler_Remote_Base();
        didfinishattack.owner = this;
        BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
    }
    void Awake()
    {

        

        
    }

    public void Attack()
    {
        if (attackRestTime>0)
        {
            return;
        }
        attackRestTime = attackInterval;
        hitRestTime = hitDelay;
        BattleEventMessage msg = new BattleEventMessage();
        BattleField.Instance.SendEvent(BattleEventType.WillAttack, new List<Warrior>() { this }, null, msg);
        if (!msg.ContinueAction)
        {
            return;
        }
        this.attackState = AttackState.Attack;
        BattleField.Instance.SendEvent(BattleEventType.DidAttack, new List<Warrior>() { this }, null, msg);
        
    }

    void Update()
    {
        attackRestTime -= Time.deltaTime;
        /////////////////////////////////////////
        List<Warrior> sponsors = new List<Warrior>() { this };
        List<Warrior> responders = new List<Warrior>();
        if (FindHitTargetHandler.Count > 0)
        {
            FindHitTargetHandler[0].HandleEvent(sponsors, responders);
        }

        if (attackState == AttackState.Attack)
        {
            this.hitRestTime -= Time.deltaTime;
            if (this.hitRestTime <= 0.0f)
            {
                this.attackState = AttackState.None;
                BattleEventMessage msg = new BattleEventMessage();
                BattleField.Instance.SendEvent(BattleEventType.WillFinishAttack, new List<Warrior>() { this }, null, msg);
                if (!msg.ContinueAction)
                {
                    return;
                }
                BattleField.Instance.SendEvent(BattleEventType.DidFinishAttack, new List<Warrior>() { this }, null, msg);
            }
        }
        else
        {
            if(responders.Count > 0)
            {
                this.Attack();
            }
        }

        if (this.moveState == MoveState.Idle)
        {
            this.rigidbody.velocity = new Vector3(0, 0, 0);
            if (responders.Count == 0 || canAttackMove)
            {
                this.moveState = MoveState.Move;
            }
        }
        else
        {
            if (this.rigidbody.velocity.x * dir > 0)
            {
                this.moveState = MoveState.Move;
            }
            else
            {
                this.moveState = MoveState.KnockBack;
            }
            if (responders.Count > 0 && !canAttackMove)
            {
                this.moveState = MoveState.Idle;
            }
            else
            {
                this.constantForce.force = new Vector3(dir * acceleration, 0, 0);
                if (this.rigidbody.velocity.x > maxMoveSpeed)
                {
                    this.rigidbody.velocity = new Vector3(maxMoveSpeed, 0, 0);
                }
            }

        }

        UpdateAnimation();

    }
    void Hit()
    {
        //FindTarget
        List<Warrior> sponsors=new List<Warrior>() { this };
        List<Warrior> responders = new List<Warrior>();
        if (FindHitTargetHandler.Count>0)
        {
            FindHitTargetHandler[0].HandleEvent(sponsors, responders);
        }
        BattleEventMessage msg=new BattleEventMessage();
        BattleField.Instance.SendEvent(BattleEventType.WillHit, sponsors, responders, msg);
        if (!msg.ContinueAction)
        {
            return;
        }
        BattleField.Instance.SendEvent(BattleEventType.DidHit, sponsors, responders, msg);


    }

}
