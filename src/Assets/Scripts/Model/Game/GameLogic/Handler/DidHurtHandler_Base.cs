using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidHurtHandler_Base : BattleEventHandler
{
    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        
        HurtEventMessage msg = param0 as HurtEventMessage;
        Debug.Log(sponsors[0].name + " hurt " + responders[0].name + ":" + msg.physicalDamage);
        foreach (Warrior warrior in responders)
        {
            warrior.hp -= msg.physicalDamage;
            if (warrior.hp<0)
            {
                if (warrior.isAttacker)
                {
                    BattleField.Instance.AttackerList.Remove(warrior);
                }
                else
                {
                    BattleField.Instance.DefenderList.Remove(warrior);
                }
                BattleField.Instance.JudgeWin();
                GameObject.Destroy(warrior.gameObject);
            }
        }
        return null;
    }
}
