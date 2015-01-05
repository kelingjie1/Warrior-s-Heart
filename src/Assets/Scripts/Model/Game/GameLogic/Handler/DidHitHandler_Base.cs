using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidHitHandler_Base : BattleEventHandler
{
    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        HitEventMessage hitmsg = param0 as HitEventMessage;
        if (responders.Count==0)
        {
            return null;
        }
        Debug.Log(sponsors[0].name + " hit " + responders[0].name);
        List<Warrior> nextResponders = new List<Warrior>();
        KnockEventMessage knockmsg = new KnockEventMessage();
        knockmsg.KnockStrength = 0;
        foreach (Warrior item in sponsors)
        {
            knockmsg.KnockStrength += item.knockback;
        }
        float dis = 0;
        int id = 0;
        for (int i = 0; i < responders.Count; i++)
        {
            float len = Mathf.Abs(responders[i].transform.localPosition.x - sponsors[0].transform.localPosition.x);
            if (len > dis)
            {
                dis = len;
                id = i;
            }
        }
        nextResponders.Add(responders[id]);
        BattleField.Instance.SendEvent(BattleEventType.WillKnock, sponsors, nextResponders, knockmsg);
        if (knockmsg.ContinueAction)
        {
            
            BattleField.Instance.SendEvent(BattleEventType.DidKnock, sponsors, nextResponders, knockmsg);
        }
        

        HurtEventMessage hurtmsg = new HurtEventMessage();
        float physicalDamageScale = 1 - responders[0].physicalDefence / (responders[0].physicalDefence + 100);
        hurtmsg.physicalDamage = hitmsg.physicalAttack * physicalDamageScale;
        BattleField.Instance.SendEvent(BattleEventType.WillHurt, sponsors, responders, hurtmsg);
        if (hurtmsg.ContinueAction)
        {
            BattleField.Instance.SendEvent(BattleEventType.DidHurt, sponsors, responders, hurtmsg);
        }
        
        return null;
    }
}
