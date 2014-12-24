using UnityEngine;
using System.Collections;
using System.Xml;

public class WarriorTemplate
{
    public string category;
    public string image;
    public int width;
    public int height;
    public WarriorTemplate(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlElement root = doc.DocumentElement;
        category = root.GetFirstTextByTag("Category");
        image = root.GetFirstTextByTag("PicPath");
        width = int.Parse(root.GetFirstTextByTag("PicXSize"));
        height = int.Parse(root.GetFirstTextByTag("PicYSize"));
    }
}
public class WarriorAttribute
{
    WarriorTemplate template;

}
