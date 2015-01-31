using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


public class ItemBagDataMrg 
{

	public static ItemBagDataMrg m_instance;
    public static string m_sConfigFile = "Config/Item/AllItem.xml";

    //list 数据 map 数据 都有同一个数据
	public XmlBagItems m_XmlBagItems;
    public Dictionary<string, XmlBagItem> m_XmlBagItemsDic = new Dictionary<string, XmlBagItem>();
	

	public ItemBagDataMrg()
	{
		LoadBagItem ();
	}
	public int LoadBagItem()
	{
		XmlSerializer xs = new XmlSerializer(typeof(XmlBagItems));
		FileStream fs = new FileStream(Global.DownloadPath + m_sConfigFile, FileMode.Open);
		m_XmlBagItems = xs.Deserialize(fs) as XmlBagItems;
        // m_XmlBagItems = null;
		fs.Close();
		if (m_XmlBagItems == null) 
		{
			//ONLY TEST
			MakeFakeData();
		}
        //转换生存dic结构便于查询
        Convert2NeedDic();
		return 0;
	}

    public void Convert2NeedDic()
    {
       foreach(XmlBagItem i in  m_XmlBagItems.bagItemList)
       {
           m_XmlBagItemsDic.Add(i.id, i);
       }
    }

	public static ItemBagDataMrg Instance
	{
		get
		{
			if (m_instance == null)
			{
				Debug.Log("new ItemBagDataMrg");
				m_instance = new ItemBagDataMrg();
			}
			return m_instance;
		}
	}

	public void MakeFakeData()
	{
		if(m_XmlBagItems == null)
			m_XmlBagItems = new XmlBagItems ();

		Debug.Log("Making fake data.");
		for (int i = 0; i < 2; i++)
		{
			XmlBagItem item = new XmlBagItem();
			item.id = i.ToString();
			item.name = "血 ["+i.ToString()+"]";
			item.picPath = i.ToString();
			item.Desc = "JIAXUE";
			item.itemType = ITMEBAGTYPE.ITEMBAG_TYPE_MATERIAL;
			
			m_XmlBagItems.bagItemList.Add(item);
		}
		SaveXml();
	}
	
	public void SaveXml()
	{

		Debug.Log("Save Xml.");
		XmlSerializer xs = new XmlSerializer(typeof(XmlBagItems));
        FileStream fs = new FileStream(Global.DownloadPath + m_sConfigFile, FileMode.Create);
		xs.Serialize(fs, m_XmlBagItems);
        fs.Close();
	}


}