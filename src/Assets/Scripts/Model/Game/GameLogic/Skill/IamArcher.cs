using UnityEngine;
using System.Collections;

public class IamArcher : Skill 
{

    public override void Attach(Warrior warrior)
    {
        base.Attach(warrior);
        warrior.canAttackMove = false;

        warrior.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
        DidFinishAttackHandler_Remote_Base didfinishattack = new DidFinishAttackHandler_Remote_Base();
        didfinishattack.owner = warrior;
        BattleField.Instance.RegisterEvent(BattleEventType.DidFinishAttack, didfinishattack);
    }
}
