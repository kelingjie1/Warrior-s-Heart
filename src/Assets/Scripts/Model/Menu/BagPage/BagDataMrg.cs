using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagDataMrg : Inventory
{
	private static BagDataMrg m_instance;

	public static string m_sConfigFile = @"/UserData/user1/inventory.xml";
 
	public static BagDataMrg Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = (BagDataMrg)FileLoader.LoadXML(m_sConfigFile, typeof(BagDataMrg));
				if (m_instance == null)
				{
					Debug.Log("Empty config.");
					m_instance = new BagDataMrg();
					m_instance.MakeFakeData();
				}
				else
				{
					Debug.Log("Load config.");
					m_instance.ClassifyData();
				}
			}
			return m_instance;
		}
	}

	public void MakeFakeData()
	{
		Debug.Log("Making fake data.");
		for (int i = 0; i < 40; i++)
		{
			Soldier soldier = new Soldier();
			soldier.id = i.ToString();
			soldier.name = "战士 ["+i.ToString()+"]";
			soldier.IconNumber = i;
			soldier.introduction = "帅的一塌糊涂";

			AddBagItem(soldier);
		}
		SaveXml();
	}

	public void SaveXml()
	{
		Debug.Log("Save Xml.");
		FileLoader.SaveXml(m_sConfigFile, this, typeof(BagDataMrg));
	}


}
