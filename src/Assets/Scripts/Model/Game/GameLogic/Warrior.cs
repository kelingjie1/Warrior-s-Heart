using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Spine;
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
    public float knockback
    {
        get
        {
            float v = attribute.power;
            return v * knockbackMultiple + knockbackAdd;
        }
    }
    public float knockbackMultiple = 1;
    public float knockbackAdd = 0;

    public float antiKnockback
    {
        get
        {
            float v = attribute.power / 20;
            return v * antiKnockbackMultiple + antiKnockbackAdd;
        }
    }
    public float antiKnockbackMultiple = 1;
    public float antiKnockbackAdd = 0;

    public float physicalAttack
    {
        get
        {
            float v = attribute.power * 2 + 50;
            return v * physicalAttackMultiple + physicalAttackAdd;
        }
    }
    public float physicalAttackMultiple = 1;
    public float physicalAttackAdd = 0;

    public float physicalDefence
    {
        get
        {
            float v = attribute.strong / 2;
            return v * physicalDefenceMultiple + physicalDefenceAdd;
        }
    }
    public float physicalDefenceMultiple = 1;
    public float physicalDefenceAdd = 0;

    public float magicAttack
    {
        get
        {
            float v = attribute.intelligence;
            return v * magicAttackMultiple + magicAttackAdd;
        }
    }
    public float magicAttackMultiple = 1;
    public float magicAttackAdd = 0;

    public float magicDefence
    {
        get
        {
            float v = attribute.intelligence / 2;
            return v * magicDefenceMultiple + magicDefenceAdd;
        }
    }
    public float magicDefenceMultiple = 1;
    public float magicDefenceAdd = 0;

    public float hitDelay
    {
        get
        {
            return attribute.template.hitDelay / AttackSpeedMultiple;
        }
    }
    public float attackInterval
    {
        get
        {
            return 1.5f / AttackSpeedMultiple;
        }
    }
    public float AttackSpeedMultiple = 1;

    public float maxHP
    {
        get
        {
            float v = 500 + attribute.strong * 20;
            return v * maxHPMultiple + maxHPAdd;
        }
    }
    public float maxHPMultiple = 1;
    public float maxHPAdd = 0;

    public float maxMoveSpeed
    {
        get
        {
            float v = 1 + attribute.agility / 20;
            return v * maxMoveSpeedMultiple + maxMoveSpeedAdd;
        }
    }
    public float maxMoveSpeedMultiple = 1;
    public float maxMoveSpeedAdd = 0;

    public float acceleration
    {
        get
        {
            float v = 10 + attribute.agility;
            return v * accelerationMultiple + accelerationAdd;
        }
    }
    public float accelerationMultiple = 1;
    public float accelerationAdd = 0;

    public float attackDistance
    {
        get
        {
            return attribute.template.attackDistance;
        }
    }

    public bool canAttackMove;
    public float guardingDistance;

    //当前属性
    public float hp;
    public float attackSpeed;
    
    //状态
	public string animationName = "";
    public float hitRestTime;
    public float attackRestTime;
    AttackState m_attackState;
    public AttackState attackState
    {
        get
        {
            return m_attackState;
        }
        set
        {
            if (m_attackState==value)
            {
                return;
            }
            m_attackState = value;
            SkeletonAnimation animation = this.GetComponent<SkeletonAnimation>();
            if (m_attackState==AttackState.Attack)
            {
                animation.state.SetAnimation(1, "attack", false).timeScale = 3;
            }
            else
            {
                if (animation.state.GetCurrent(1)!=null)
                {
                    animation.state.GetCurrent(1).OnEnd(animation.state, 1);
                }
                
            }
        }
    }
    public int attackLock;
    public int moveLock;
    MoveState m_moveState;
    public MoveState moveState
    {
        get
        {
            return m_moveState;
        }
        set
        {
            if (m_moveState == value)
            {
                return;
            }
            m_moveState = value;
            SkeletonAnimation animation = this.GetComponent<SkeletonAnimation>();
            if (m_moveState == MoveState.Idle)
            {
                animation.state.SetAnimation(0, "idle", true);
            }
            else if (m_moveState == MoveState.Move)
            {
                animation.state.SetAnimation(0, "move", true);
            }
            else if (m_moveState == MoveState.KnockBack)
            {
                animation.state.SetAnimation(0, "knockback", false);
            }
        }
    }
    public bool hasEnemyInAttackDistance;
    public bool isNearWall;
    List<Buff> buffList = new List<Buff>();
    List<Buff> removeBuffList = new List<Buff>();
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
    //满状态
    public void Reset()
    {
        hp = maxHP;
    }

    bool m_pause;
	public bool pause
	{
        set
        {
            m_pause = value;
            if (m_pause)
            {
                this.GetComponent<SkeletonAnimation>().state.TimeScale = 0;
            }
            else
            {
				this.GetComponent<SkeletonAnimation>().state.TimeScale = 1;
            }
        }
        get
        {
            return m_pause;
        }
		
	}

    public void ReadFromXML(XmlElement item)
    {
        name = item.Name;
        isAttacker = bool.Parse(item.GetAttribute("IsAttacker"));
        attribute.template = new WarriorTemplate(Config.WarriorPath + item.GetAttribute("WarriorTemplate"));
        transform.localPosition = new Vector3(int.Parse(item.GetAttribute("X")), BattleField.Instance.floorHeight+100, -10);
        attribute.powerPoint = int.Parse(item.GetAttribute("PowerPoint"));
        attribute.agilityPoint = int.Parse(item.GetAttribute("AgilityPoint"));
        attribute.strongPoint = int.Parse(item.GetAttribute("StrongPoint"));
        attribute.intelligencePoint = int.Parse(item.GetAttribute("IntelligencePoint"));

        guardingDistance = int.Parse(item.GetAttribute("GuardingDistance"));

        if (attribute.template.category.Equals("Fighter"))
        {
            canAttackMove = true;

            this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
            DidFinishAttackHandler_Melee_Base didfinishattack = new DidFinishAttackHandler_Melee_Base();
            didfinishattack.owner = this;
            BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
        }
        else
        {
            canAttackMove = false;

            this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
            DidFinishAttackHandler_Remote_Base didfinishattack = new DidFinishAttackHandler_Remote_Base();
            didfinishattack.owner = this;
            BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
        }

        SkeletonAnimation animation = this.GetComponent<SkeletonAnimation>();
        //"Animation/" + attribute.template.category + "_skel"
        animation.skeletonDataAsset = Resources.Load("Animation/" + attribute.template.category + "_skel") as SkeletonDataAsset;
        animation.Reset();
        Reset();


    }
    public bool isAttacker;


    public static Warrior Create()
    {
        return ResourceManager.Load("Prefab/Game/Warrior").GetComponent<Warrior>();
    }

//     public void TestMelee()
//     {
//         //近战
//         knockback = 2f;
//         maxMoveSpeed = 1.0f;
//         acceleration = 1f;
//         attackDistance = 100;
//         hitDelay = 0.3f;
//         attackInterval = 1;
//         canAttackMove = true;
//         this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
//         DidFinishAttackHandler_Melee_Base didfinishattack = new DidFinishAttackHandler_Melee_Base();
//         didfinishattack.owner = this;
//         BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
//     }
//     public void TestRemote()
//     {
//         //远程
//         knockback = 5f;
//         maxMoveSpeed = 1.0f;
//         acceleration = 1f;
//         attackDistance = 700;
//         hitDelay = 0.3f;
//         attackInterval = 2;
//         canAttackMove = false;
//         this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
//         DidFinishAttackHandler_Remote_Base didfinishattack = new DidFinishAttackHandler_Remote_Base();
//         didfinishattack.owner = this;
//         BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
//     }
    void Awake()
    {

        

        
    }

    public void AddBuff(Buff buff)
    {
        buffList.Add(buff);
        buff.Attach(this);
    }
    public void RemoveBuff(Buff buff)
    {
        removeBuffList.Add(buff);
        buff.Detach();
    }
    public void Attack()
    {
        if (attackLock>0)
        {
            return;
        }
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
    public void Move()
    {
        if (moveLock>0)
        {
            return;
        }
        this.moveState = MoveState.Move;
    }
    void Update()
    {
        if (pause)
        {
            return;
        }
        foreach (Buff buff in buffList)
        {
            buff.Update();
        }
        foreach (Buff buff in removeBuffList)
        {
            buffList.Remove(buff);
        }
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
        else if(moveState!=MoveState.KnockBack)
        {
            if(responders.Count > 0)
            {
                this.Attack();
            }
        }

        if (this.moveState == MoveState.KnockBack)
        {
            if (this.rigidbody.velocity.x*dir>0)
            {
                this.Move();
            }
        }

        if (this.moveState == MoveState.Idle&&moveLock==0)
        {
            if (responders.Count == 0 || canAttackMove)
            {
                this.Move();
            }
        }
        else
        {
            if (this.attackState == AttackState.Attack && !canAttackMove)
            {
                this.moveState = MoveState.Idle;
            }

            if (this.moveState == MoveState.Move || this.moveState == MoveState.KnockBack)
            {
                this.constantForce.force = new Vector3(dir * acceleration, 0, 0);
                if (this.rigidbody.velocity.x > maxMoveSpeed)
                {
                    this.rigidbody.velocity = new Vector3(maxMoveSpeed, 0, 0);
                }
            }
            else
            {
                this.constantForce.force = new Vector3(0, 0, 0);
                this.rigidbody.velocity = new Vector3(0, 0, 0);
            }

        }

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
        HitEventMessage msg = new HitEventMessage();
        BattleField.Instance.SendEvent(BattleEventType.WillHit, sponsors, responders, msg);
        if (!msg.ContinueAction)
        {
            return;
        }
        BattleField.Instance.SendEvent(BattleEventType.DidHit, sponsors, responders, msg);


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="LeftWall"||collision.gameObject.name=="RightWall")
        {
            isNearWall = true;
            List<Warrior> sponsors = new List<Warrior>() { this };
            List<Warrior> responders = new List<Warrior>();
            KnockWallEventMessage msg = new KnockWallEventMessage();
            BattleField.Instance.SendEvent(BattleEventType.WillKnockWall, sponsors, responders, msg);
            if (!msg.ContinueAction)
            {
                return;
            }
            BattleField.Instance.SendEvent(BattleEventType.DidKnockWall, sponsors, responders, msg);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "LeftWall" || collision.gameObject.name == "RightWall")
        {
            isNearWall = false;
        }
    }

}
