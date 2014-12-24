using UnityEngine;
using System.Collections;
using System.Xml;

public class WarriorTemplate
{
    public string category;
    public string image;
    public int width;
    public int height;

    public float power;
    public float strong;
    public float intelligence;
    public float agility;

    public float powerGrow;
    public float strongGrow;
    public float intelligenceGrow;
    public float agilityGrow;
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

        power = float.Parse(root.GetFirstTextByTag("Power"));
        strong = float.Parse(root.GetFirstTextByTag("Strong"));
        intelligence = float.Parse(root.GetFirstTextByTag("Intelligence"));
        agility = float.Parse(root.GetFirstTextByTag("Agility"));

        powerGrow = float.Parse(root.GetFirstTextByTag("PowerGrow"));
        strongGrow = float.Parse(root.GetFirstTextByTag("StrongGrow"));
        intelligenceGrow = float.Parse(root.GetFirstTextByTag("IntelligenceGrow"));
        agilityGrow = float.Parse(root.GetFirstTextByTag("AgilityGrow"));

        colliderWidth = float.Parse(root.GetFirstTextByTag("MaxX")) - float.Parse(root.GetFirstTextByTag("MinX"));
        colliderHeight = float.Parse(root.GetFirstTextByTag("MaxY")) - float.Parse(root.GetFirstTextByTag("MinY"));


    }
}
public class WarriorAttribute
{
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
            return template.power + template.powerGrow * powerPoint;
        }
    }
    public float strong
    {
        get
        {
            return template.strong + template.strongGrow * strongPoint;
        }
    }
    public float intelligence
    {
        get
        {
            return template.intelligence + template.intelligenceGrow * intelligencePoint;
        }
    }
    public float agility
    {
        get
        {
            return template.agility + template.agilityGrow * agilityPoint;
        }
    }
}
