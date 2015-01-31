using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidHurtHandler_Base : BattleEventHandler
{
    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        
        HurtEventMessage msg = param0 as HurtEventMessage;
        //Debug.Log(sponsors[0].name + " hurt " + responders[0].name + ":" + msg.physicalDamage);
        Vector3 pos = responders[0].transform.localPosition;
        pos.y += 100;
        BattleField.Instance.ShowMessage("-" + (int)msg.physicalDamage, pos, Color.red);
        foreach (Warrior warrior in responders)
        {
            warrior.hp -= msg.physicalDamage;
            if (warrior.hp<0)
            {
                warrior.Die();

            }
        }
        return null;
    }
}
