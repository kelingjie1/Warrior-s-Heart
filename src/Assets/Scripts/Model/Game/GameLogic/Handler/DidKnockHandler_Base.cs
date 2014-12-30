using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidKnockHandler_Base : BattleEventHandler 
{
    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        if (responders.Count==0)
        {
            return null;
        }
        KnockEventMessage knockmsg = param0 as KnockEventMessage;
        Debug.Log(sponsors[0].name + " knock " + responders[0].name + ":" + knockmsg.KnockStrength);
        responders[0].moveState = MoveState.KnockBack;
        responders[0].rigidbody.AddForce(new Vector3(-knockmsg.KnockStrength * responders[0].dir, 0, 0), ForceMode.Impulse);
        return null;
    }
}
