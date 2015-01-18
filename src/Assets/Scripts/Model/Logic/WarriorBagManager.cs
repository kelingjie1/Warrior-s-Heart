using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using game_proto;

public class WarriorBagManager 
{

    static WarriorBagManager m_instance;
    public static WarriorBagManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new WarriorBagManager();
            }
            return m_instance;
        }
    }

    public List<WarriorItem> warriorItemList;

    public void GetItemListFromServer()
    {

    }
}
