using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagDataMrg : Inventory
{
	public static BagDataMrg m_instance;

	public static BagDataMrg Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = (BagDataMrg)FileLoader.LoadXML("bag_data.xml", typeof(BagDataMrg));
				if (m_instance == null)
				{
					Debug.Log("empty config.");
					m_instance = new BagDataMrg();
				}
				else
				{
					Debug.Log("load config.");
					m_instance.ClassifyData();
				}
			}
			return m_instance;
		}
	}

	/*BagDataMrg()
	{
		for (int i = 0; i < 40; i++)
		{
			Soldier soldier = new Soldier();
			soldier.id = i.ToString();
			soldier.name = "战士 ["+i.ToString()+"]";
			soldier.IconNumber = i;
			soldier.introduction = "帅的一塌糊涂";

			AddBagItem(soldier);
		}
	}*/

	public void SaveXml()
	{
		FileLoader.SaveXml("bag_data.xml", this, typeof(BagDataMrg));
	}


}
