using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using game_proto;

//ui 数据结构 用户数据拉取回来以后直接放到这



public class UIItemBagPage : BasePage {


    static UIItemBagPage m_instance;
    
    //物品UI数据
    Dictionary<string, UIOneItem> m_UIAllItemsByIdDic;

    //xml配置数据
    ItemBagDataMrg m_XMLItemDataMrg;
    //控制变量
    public CATEGROYTYPE m_SelectCategoryIndex = CATEGROYTYPE.CATEGORY_TYEP_ALL;
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


    public void RefreshSurface()
    {
        foreach (KeyValuePair<string, UIOneItem> oneItem in m_UIAllItemsByIdDic)
        {
            string ItemID = oneItem.Key;
            XmlBagItem stXmlBagItem = m_XMLItemDataMrg.FindXmlBagItemById(ItemID);
            gameObject.FindChild("ItemBagList").AddChild(oneItem.Value.gameObject);
            oneItem.Value.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            
        }

        //刷新界面
        gameObject.FindChild("ItemBagList").GetComponent<UIGrid>().Reposition();
        gameObject.FindChild("ItemBagList").GetComponent<UIScrollView>().ResetPosition();

        //SetCurrentItem(current_choose_item);
    }

	void Awake()
	{
  
        m_XMLItemDataMrg = ItemBagDataMrg.Instance;
        m_UIAllItemsByIdDic = new Dictionary<string, UIOneItem>();

		//test data
        List<UIOneItem> Items = new List<UIOneItem>();
        UIOneItem stUIOneItem = UIOneItem.Instance;
        stUIOneItem.m_BagItem.ref_id = "0";
        stUIOneItem.m_BagItem.count = 10;
        Items.Add(stUIOneItem);
        stUIOneItem = UIOneItem.Instance;
        stUIOneItem.m_BagItem.ref_id = "1";
        stUIOneItem.m_BagItem.count = 11;
        Items.Add(stUIOneItem);
        foreach (UIOneItem i in Items) 
		{
            m_UIAllItemsByIdDic.Add(i.m_BagItem.ref_id, i);
		}

        RefreshSurface();


	}

}
