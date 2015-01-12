using UnityEngine;
using System.Collections;

public enum BattleEventType
{
    WillStartBattle,
    DidStartBattle,
    WillAttack,
    DidAttack,
    WillFinishAttack,
    DidFinishAttack,
    WillHit,
    DidHit,
    WillKnock,
    DidKnock,
    WillHurt,
    DidHurt,
    WillDie,
    DidDie,
    WillKnockWall,
    DidKnockWall,
    ArriveTopSpeed,
    StopKnockBack,
    KnockScreenEdge,
    WillPrepareSpell,
    DidPrepareSpell,
    WillStartSpell,
    DidStartSpell,
    WillFinishSpell,
    DidFinishSpell,
    WillBreakSpell,
    DidBreakSpell,
    WillBeBreakSpell,
    DidBeBreakSpell,
    WillUpdate,
    DidUpdate,
}

public class BattleEventMessage
{
    public bool ContinueAction = true;
}


public class KnockEventMessage : BattleEventMessage
{
    public float KnockStrength;
}
public class HitEventMessage : BattleEventMessage
{
    public float physicalAttack;
    public float magicAttack;
    public float absoluteAttack;
    public Ammo ammo;
}
public class HurtEventMessage : BattleEventMessage
{
    public float physicalDamage;
    public float magicDamage;
    public float absoluteDamage;
}

public class KnockWallEventMessage : BattleEventMessage
{
    
}

