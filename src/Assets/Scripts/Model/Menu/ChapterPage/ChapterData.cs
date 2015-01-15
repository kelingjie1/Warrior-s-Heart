using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;

//章节节点
public class Section
{
	//章节标题
	[XmlElementAttribute("Title")]
	public string title;
	//描述
	[XmlElementAttribute("Desc")]
	public string desc;
	//章节背景图
	[XmlElementAttribute("BackGroundPic")]
	public string background;
	
	[XmlArrayAttribute("Sences")]
	public List<Sence> sections = new List<Sence>();

	public int percent_x;
	public int percent_y;

	public Section()
	{
		percent_x = m_randomHelper.Next(1,100);
		percent_y = m_randomHelper.Next(1,100);
	}

	public Vector3 Position
	{
		get {
			return new Vector3 (percent_x * Screen.width / 100 - Screen.width / 2, percent_y * Screen.height / 100 - Screen.height / 2, 0);
		}
	}

	static System.Random m_randomHelper = new System.Random(unchecked((int)DateTime.Now.Ticks));
}


//关卡节点
public class Sence
{
	//场景标题
	[XmlElementAttribute("Title")]
	public string title;
	
	//场景描述
	[XmlElementAttribute("Desc")]
	public string desc;
	
	//场景类型(普通/精英)
	[XmlElementAttribute("Type")]
	public string type;
	
	//章节背景图id
	[XmlElementAttribute("BackGroundPic")]
	public string background;
	
	//奖励
	[XmlElementAttribute("Encourage")]
	public SenceEncourage encourage;

	public int percent_x;
	public int percent_y;

	public Sence()
	{
		percent_x = m_randomHelper.Next(1,100);
		percent_y = m_randomHelper.Next(1,100);
	}

	public Vector3 Position
	{
		get {
			return new Vector3 (percent_x * Screen.width / 100 - Screen.width / 2, percent_y * Screen.height / 100 - Screen.height / 2, 0);
		}
	}

	static System.Random m_randomHelper = new System.Random(unchecked((int)DateTime.Now.Ticks));
}
//关卡奖励
public class SenceEncourage
{
	//黄金奖励
	[XmlElementAttribute("gold")]
	public string encourage_gold;
	
	//经验奖励
	[XmlElementAttribute("exp")]
	public string encourage_exp;
	
	//物品奖励1
	[XmlElementAttribute("item1")]
	public string encourage_item1;
	
	//物品奖励2
	[XmlElementAttribute("item2")]
	public string encourage_item2;
	
	//物品奖励3
	[XmlElementAttribute("item3")]
	public string encourage_item3;
}
