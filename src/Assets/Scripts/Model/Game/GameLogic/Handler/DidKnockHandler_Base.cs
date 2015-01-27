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
        responders[0].rigidbody.velocity = new Vector3(0, 0, 0);
        responders[0].rigidbody.AddForce(new Vector3(-knockmsg.KnockStrength * responders[0].dir, 0, 0), ForceMode.Impulse);
        
        if (responders[0].isNearWall)
        {
            List<Warrior> nextsponsors = new List<Warrior>() { responders[0] };
            List<Warrior> nextresponders = new List<Warrior>();
            KnockWallEventMessage msg = new KnockWallEventMessage();
            BattleField.Instance.SendEvent(BattleEventType.WillKnockWall, nextsponsors, nextresponders, msg);
            if (!msg.ContinueAction)
            {
                return null;
            }
            BattleField.Instance.SendEvent(BattleEventType.DidKnockWall, nextsponsors, nextresponders, msg);
        }
        return null;
    }
}
