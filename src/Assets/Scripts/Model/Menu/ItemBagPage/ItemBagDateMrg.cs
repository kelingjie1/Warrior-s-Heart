using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


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
                XmlSerializer xs = new XmlSerializer(typeof(BagDataMrg));
                FileStream fs = new FileStream(Config.BaseDataPath + m_sConfigFile, FileMode.Open);
				m_instance = xs.Deserialize(fs) as ItemBagDataMrg;
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
        XmlSerializer xs = new XmlSerializer(typeof(ItemBagDataMrg));
        FileStream fs = new FileStream(Config.BaseDataPath + m_sConfigFile, FileMode.OpenOrCreate);
        xs.Serialize(fs, this);
	}


}