using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UIItemBagPage : BasePage {

	static UIItemBagPage m_instance;
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
		List<string> Items = new List<string>();
		Items.Add ("1");
		Items.Add ("2");
		ItemBagDataMrg m_test = ItemBagDataMrg.Instance;

	}

}
