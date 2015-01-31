using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidKnockWallHandler : BattleEventHandler 
{

    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        KnockWallEventMessage msg = param0 as KnockWallEventMessage;
        //Debug.Log(sponsors[0].name + " knockwall");
        foreach (Warrior warrior in sponsors)
        {
            BuffGiddy buff = new BuffGiddy();
            buff.restTime = 1f;
            warrior.AddBuff(buff);
        }
        return null;
    }
}
