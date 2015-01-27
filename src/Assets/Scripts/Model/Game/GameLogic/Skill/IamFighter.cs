using UnityEngine;
using System.Collections;

public class IamFighter : Skill 
{
    public override void Attach(Warrior warrior)
    {
        base.Attach(warrior);
        warrior.canAttackMove = true;

        warrior.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
        DidFinishAttackHandler_Melee_Base didfinishattack = new DidFinishAttackHandler_Melee_Base();
        didfinishattack.owner = warrior;
        BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
    }
}
