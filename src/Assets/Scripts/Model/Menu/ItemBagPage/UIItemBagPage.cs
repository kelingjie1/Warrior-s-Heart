using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using game_proto;

//ui 数据结构 用户数据拉取回来以后直接放到这
public class UIOneItem : MonoBehaviour
{
    public UIOneItem()
    {
        m_BagItem = new BagItem();
    }
    //协议数据结构
    public BagItem m_BagItem;
    //maybe other

}


public class UIItemBagPage : BasePage {

    static UIItemBagPage m_instance;

    Dictionary<string, UIOneItem> m_UIAllItemsByIdDic = new Dictionary<string, UIOneItem>();
	

	public static UIItemBagPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.LoadGameObject("Prefab/Menu/ItemBagPage/ItemBagPage").GetComponent<UIItemBagPage>();
			}
			return m_instance;
		}
	}

	void Awake()
	{
        //xml配置数据
        ItemBagDataMrg m_test = ItemBagDataMrg.Instance;


		//test data
        List<UIOneItem> Items = new List<UIOneItem>();
        UIOneItem stUIOneItem = new UIOneItem();
        stUIOneItem.m_BagItem.ref_id = "1";
        stUIOneItem.m_BagItem.count = 10;
        Items.Add(stUIOneItem);
        stUIOneItem = new UIOneItem();
        stUIOneItem.m_BagItem.ref_id = "2";
        stUIOneItem.m_BagItem.count = 11;
        Items.Add(stUIOneItem);
        foreach (UIOneItem i in Items) 
		{
            m_UIAllItemsByIdDic.Add(i.m_BagItem.ref_id, i);
		}


	}

}
