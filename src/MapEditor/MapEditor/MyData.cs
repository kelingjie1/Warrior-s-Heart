using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace MapEditor
{
    public class WarriorTemplate
    {
        public string image;
        public int width;
        public int height;
        public WarriorTemplate(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlElement pic = (XmlElement)root.GetElementsByTagName("PicInfo").Item(0);
            image = ((XmlElement)root.GetElementsByTagName("PicPath").Item(0)).InnerText;
            width = int.Parse(((XmlElement)root.GetElementsByTagName("PicXSize").Item(0)).InnerText);
            height = int.Parse(((XmlElement)root.GetElementsByTagName("PicYSize").Item(0)).InnerText);
        }
    }
    public class ObjBase
    {
        public bool locked;
    }
    public class Warrior : ObjBase
    {
        public string name;
        public WarriorTemplate template;
        public int x;
        public string path;
        public int guardingDistance;
        public int powerPoint;
        public int agilityPoint;
        public int strongPoint;
        public int intelligencePoint;
        public Warrior()
        {
            name = "unname";
            x = 100;
        }
    }
    public class Adornment : ObjBase
    {
        public string name;
        public string image;
        public int x;
        public int y;
        public int width;
        public int height;
        public Adornment()
        {
            x = 100;
            y = 100;
            name = "unname";
            width = 100;
            height = 100;
        }
    }
}
