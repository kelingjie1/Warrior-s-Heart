using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Spine;
using game_proto;
using NCalc;
using System;
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
    WarriorItem warriorItem;

    //属性
    public float power
    {
        get
        {
            return warriorItem.power + warriorItem.power_grow * warriorItem.power_point;
        }
    }
    public float agility
    {
        get
        {
            return warriorItem.agility + warriorItem.agility_grow * warriorItem.agility_point;
        }
    }
    public float strong
    {
        get
        {
            return warriorItem.strong + warriorItem.strong_grow * warriorItem.strong_point;
        }
    }

    public float intelligence
    {
        get
        {
            return warriorItem.intelligence + warriorItem.intelligence_grow * warriorItem.intelligence_point;
        }
    }


    public float knockback
    {
        get
        {
            float v = CalcExpression(template.knockbackExpression);
            return v * knockbackMultiple + knockbackAdd;
        }
    }
    public float knockbackMultiple = 1;
    public float knockbackAdd = 0;

    public float antiKnockback
    {
        get
        {
            float v = CalcExpression(template.antiKnockbackExpression);
            return v * antiKnockbackMultiple + antiKnockbackAdd;
        }
    }
    public float antiKnockbackMultiple = 1;
    public float antiKnockbackAdd = 0;

    public float physicalAttack
    {
        get
        {
            float v = CalcExpression(template.physicalAttackExpression);
            return v * physicalAttackMultiple + physicalAttackAdd;
        }
    }
    public float physicalAttackMultiple = 1;
    public float physicalAttackAdd = 0;

    public float physicalDefence
    {
        get
        {
            float v = CalcExpression(template.physicalDefenceExpression);
            return v * physicalDefenceMultiple + physicalDefenceAdd;
        }
    }
    public float physicalDefenceMultiple = 1;
    public float physicalDefenceAdd = 0;

    public float magicAttack
    {
        get
        {
            float v = CalcExpression(template.magicAttackExpression);
            return v * magicAttackMultiple + magicAttackAdd;
        }
    }
    public float magicAttackMultiple = 1;
    public float magicAttackAdd = 0;

    public float magicDefence
    {
        get
        {
            float v = CalcExpression(template.magicDefenceExpression);
            return v * magicDefenceMultiple + magicDefenceAdd;
        }
    }
    public float magicDefenceMultiple = 1;
    public float magicDefenceAdd = 0;

    public float hitDelay
    {
        get
        {
            return template.hitDelay / attackSpeed;
        }
    }
    public float attackSpeed
    {
        get
        {
            return CalcExpression(template.attackSpeedExpression);
        }
    }
    public float attackInterval
    {
        get
        {
            return 1 / attackSpeed;
        }
    }

    public float AttackSpeedMultiple = 1;

    public float maxHP
    {
        get
        {
            float v = CalcExpression(template.maxHPExpression);
            return v * maxHPMultiple + maxHPAdd;
        }
    }
    public float maxHPMultiple = 1;
    public float maxHPAdd = 0;

    public float maxMoveSpeed
    {
        get
        {
            float v = CalcExpression(template.maxMoveSpeedExpression);
            return v * maxMoveSpeedMultiple + maxMoveSpeedAdd;
        }
    }
    public float maxMoveSpeedMultiple = 1;
    public float maxMoveSpeedAdd = 0;

    public float acceleration
    {
        get
        {
            float v = CalcExpression(template.accelerationExpression);
            return v * accelerationMultiple + accelerationAdd;
        }
    }
    public float accelerationMultiple = 1;
    public float accelerationAdd = 0;

    public float attackDistance
    {
        get
        {
            return CalcExpression(template.attackDistanceExpression);
        }
    }

    public bool canAttackMove;
    public float guardingDistance;

    //当前属性
    float m_hp;
    public float hp
    {
        get
        {
            return m_hp;
        }
        set
        {
            m_hp = value;
            if (isAttacker)
            {
                if (id >= 0 && id<GamePage.Instance.attackerBattlePanelList.Count)
                {
                    GamePage.Instance.attackerBattlePanelList[id].HPBar.value = this.hp / this.maxHP;
                }
            }
            else
            {
                int id = BattleField.Instance.DefenderList.IndexOf(this);
                if (id >= 0 && id < GamePage.Instance.defenderBattlePanelList.Count)
                {
                    GamePage.Instance.defenderBattlePanelList[id].HPBar.value = this.hp / this.maxHP;
                }
            }
        }
    }

    public bool isAttacker;
    //状态
    public int id;
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
            SkeletonData data = animation.state.Data.SkeletonData;
            if (m_attackState==AttackState.Attack)
            {
                Spine.Animation ani = data.FindAnimation("attack");
                animation.state.SetAnimation(1, ani, false).TimeScale = ani.Duration / template.animationDic["attack"].duration * attackSpeed;
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
            SkeletonData data = animation.state.Data.SkeletonData;
            if (m_moveState == MoveState.Idle)
            {
                Spine.Animation ani = data.FindAnimation("idle");
                animation.state.SetAnimation(0, ani, true).TimeScale = ani.Duration / template.animationDic["idle"].duration;
            }
            else if (m_moveState == MoveState.Move)
            {
                Spine.Animation ani = data.FindAnimation("move");
                animation.state.SetAnimation(0, ani, true).TimeScale = ani.Duration / template.animationDic["move"].duration * Math.Abs(rigidbody.velocity.x);
            }
            else if (m_moveState == MoveState.KnockBack)
            {
                Spine.Animation ani = data.FindAnimation("move");
                animation.state.SetAnimation(0, ani, true).TimeScale = ani.Duration / template.animationDic["move"].duration * Math.Abs(rigidbody.velocity.x);
            }
        }
    }
    public bool hasEnemyInAttackDistance;
    public bool isNearWall;
    List<Buff> buffList = new List<Buff>();
    List<Buff> removeBuffList = new List<Buff>();
    List<Skill> skillList = new List<Skill>();
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

    float CalcExpression(string expression)
    {
        Expression exp = new Expression(expression);
        exp.Parameters["pow"] = power;
        exp.Parameters["agi"] = agility;
        exp.Parameters["str"] = strong;
        exp.Parameters["int"] = intelligence;
        return (float)Convert.ToDouble(exp.Evaluate());
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
    void LoadTemplate(string path)
    {
        template = WarriorTemplateManager.Instance.Get(path);
        BoxCollider collider = this.GetComponent<BoxCollider>();
        collider.size = new Vector3(template.colliderWidth, template.colliderHeight, 100);
        collider.center = new Vector3(template.colliderCenterX, template.colliderCenterY, 0);
        foreach (string skillname in template.skillList)
        {
            Type type = Type.GetType(skillname);
            Skill skill = type.Assembly.CreateInstance(skillname) as Skill;
            if (skill != null)
            {
                AddSkill(skill);
            }
            else
            {
                Debug.LogError("Skill Class:" + skillname + "  not found");
            }
        }
        SkeletonAnimation animation = this.GetComponent<SkeletonAnimation>();
        //"Animation/" + template.category + "_skel"
        animation.skeletonDataAsset = ResourceManager.Load("Animation/" + template.name + "_skel") as SkeletonDataAsset;
        animation.Reset();
        Reset();
    }
    public void InitWithWarriorData(WarriorData data)
    {
        warriorData = data;

        warriorItem = new WarriorItem();
        warriorItem.name = warriorData.name;
        warriorItem.ref_id = data.template;
        warriorItem.power_grow = 1;
        warriorItem.agility_grow = 1;
        warriorItem.strong_grow = 1;
        warriorItem.intelligence_grow = 1;
        warriorItem.power_point = warriorData.powerPoint;
        warriorItem.agility_point = warriorData.agilityPoint;
        warriorItem.strong_point = warriorData.strongPoint;
        warriorItem.intelligence_point = warriorData.intelligencePoint;

        InitWithWarriorItem(warriorItem);

        isAttacker = warriorData.isAttacker;

        transform.localPosition = new Vector3(warriorData.x, BattleField.Instance.mapData.floorHeight + template.height, -10);


        
    }

    public void InitWithWarriorItem(WarriorItem item)
    {
        warriorItem = item;
        name = item.name;
        LoadTemplate(item.ref_id);
        
    }

    public WarriorTemplate template;
    public WarriorData warriorData;

    public static Warrior Create()
    {
        return ResourceManager.LoadGameObject("Prefab/Game/Warrior").GetComponent<Warrior>();
    }

    void Awake()
    {

        

        
    }
    public void AddSkill(Skill skill)
    {
        skillList.Add(skill);
        skill.Attach(this);
    }

    public void RemoveSkill(Skill skill)
    {
        skillList.Remove(skill);
        skill.Detach();
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

    public void Die()
    {
        if (isAttacker)
        {
            BattleField.Instance.AttackerList.Remove(this);
        }
        else
        {
            BattleField.Instance.DefenderList.Remove(this);
        }
        BattleField.Instance.JudgeWin();
        GameObject.Destroy(gameObject);
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
        else if(moveState!=MoveState.KnockBack||canAttackMove)
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
        if (m_moveState == MoveState.Move || m_moveState == MoveState.KnockBack)
        {
            SkeletonAnimation animation = this.GetComponent<SkeletonAnimation>();
            SkeletonData data = animation.state.Data.SkeletonData;
            Spine.Animation ani = data.FindAnimation("move");
            animation.state.GetCurrent(0).TimeScale = ani.Duration / template.animationDic["move"].duration * Math.Abs(rigidbody.velocity.x);
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
