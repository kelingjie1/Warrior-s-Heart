using UnityEngine;
using System.Collections;
using System.Xml;
using game_proto;

public class WarriorTemplate
{
    public string category;
    public string image;
    public int width;
    public int height;

    public float colliderWidth;
    public float colliderHeight;
    public WarriorTemplate(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlElement root = doc.DocumentElement;
        category = root.GetFirstTextByTag("Category");
        image = root.GetFirstTextByTag("PicPath");
        width = int.Parse(root.GetFirstTextByTag("PicXSize"));
        height = int.Parse(root.GetFirstTextByTag("PicYSize"));

        colliderWidth = float.Parse(root.GetFirstTextByTag("MaxX")) - float.Parse(root.GetFirstTextByTag("MinX"));
        colliderHeight = float.Parse(root.GetFirstTextByTag("MaxY")) - float.Parse(root.GetFirstTextByTag("MinY"));


    }
}
public class WarriorAttribute
{
    public WarriorItem warriorItem;
    public WarriorTemplate template;
    public int level;
    public int powerPoint;
    public int strongPoint;
    public int intelligencePoint;
    public int agilityPoint;
    public float power
    {
        get
        {
            if (warriorItem!=null)
            {
                return warriorItem.power + warriorItem.power_grow * warriorItem.power_point;   
            }
            else
            {
                return powerPoint;
            }
        }
    }
    public float strong
    {
        get
        {
            if (warriorItem != null)
            {
                return warriorItem.strong + warriorItem.strong_grow * warriorItem.strong_point;
            }
            else
            {
                return strongPoint;
            }
        }
    }
    public float intelligence
    {
        get
        {
            if (warriorItem != null)
            {
                return warriorItem.intelligence + warriorItem.intelligence_grow * warriorItem.intelligence_point;
            }
            else
            {
                return intelligencePoint;
            }
        }
    }
    public float agility
    {
        get
        {
            if (warriorItem != null)
            {
                return warriorItem.agility + warriorItem.agility_grow * warriorItem.agility_point;
            }
            else
            {
                return agilityPoint;
            }
        }
    }
    
}
