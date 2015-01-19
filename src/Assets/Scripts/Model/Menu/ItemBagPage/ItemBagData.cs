using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
//物品xml

public class BagItems
{
	public List<BagItem> bagItemList = new List<BagItem>();
}


public class BagItem
{
	//章节标题

	public string id;

	public string name;
	//描述
	public string Desc;
	// pIC
	public string picPath;

}



