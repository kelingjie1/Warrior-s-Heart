using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
//物品xml

public enum ITMEBAGTYPE 
{
	ITMEBAG_TYPE_ALL = 0,
	ITEMBAG_TYPE_MATERIAL,

}
public class XmlBagItems
{
	public List<XmlBagItem> bagItemList = new List<XmlBagItem>();
}


public class XmlBagItem
{
	public string id;

	public string name;
	//描述
	public string Desc;
	// pIC
	public string picPath;

	public ITMEBAGTYPE itemType;
}



