using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
//物品xml

public enum CATEGROYTYPE
{
    CATEGORY_TYEP_ALL = 0,
    CATEGORY_TYPE_EQUITMENT,        //装备
    CATEGORY_TYPE_CONSUM,           //消耗品
    CATEGORY_TYPE_FRAGMENG,         //碎片
}
public enum ITMEBAGTYPE 
{
	ITMEBAG_TYPE_OTHERS = 0,
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

    public CATEGROYTYPE CategoryType;

    public ITMEBAGTYPE itemType;
}



