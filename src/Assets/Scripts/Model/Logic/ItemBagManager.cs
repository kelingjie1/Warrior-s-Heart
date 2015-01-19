using UnityEngine;
using System.Collections;
using game_proto;
using System.Collections.Generic;
public class ItemBagManager
{
    static ItemBagManager m_instance;
    public static ItemBagManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new ItemBagManager();
            }
            return m_instance;
        }
    }

    public List<BagItem> bagItemList;

    public void GetItemListFromServer()
    {
   
        
    }
}
