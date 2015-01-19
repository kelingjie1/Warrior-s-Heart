using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ItemBagDataMrg : BagItems 
{
	public static ItemBagDataMrg m_instance;
	
	public static string m_sConfigFile = @"Download\Config\Item\AllItem.xml";
	
	public static ItemBagDataMrg Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = (ItemBagDataMrg)FileLoader.LoadXML(m_sConfigFile, typeof(ItemBagDataMrg));
				if (m_instance == null)
				{
					Debug.Log("Empty config.");
					m_instance = new ItemBagDataMrg();
					m_instance.MakeFakeData();
				}
				else
				{
					Debug.Log("Load config.");
				}
			}
			return m_instance;
		}
	}

	public void MakeFakeData()
	{
		if(m_instance == null)
			m_instance =   new ItemBagDataMrg ();

		Debug.Log("Making fake data.");
		for (int i = 0; i < 2; i++)
		{
			BagItem item = new BagItem();
			item.id = i.ToString();
			item.name = "血 ["+i.ToString()+"]";
			item.picPath = i.ToString();
			item.Desc = "JIAXUE";
			
			m_instance.bagItemList.Add(item);
		}
		SaveXml();
	}
	
	public void SaveXml()
	{

		Debug.Log("Save Xml.");
		FileLoader.SaveXml(m_sConfigFile, m_instance, typeof(ItemBagDataMrg));
	}


}