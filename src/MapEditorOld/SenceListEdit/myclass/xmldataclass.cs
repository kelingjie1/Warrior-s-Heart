using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace EditToolsApp.myclass
{
    [XmlRootAttribute("root", Namespace = "abc.abc", IsNullable = false)]

    public class Root
    {
        [XmlArrayAttribute("Sections")]
        public List<Section> sections
        {
            get;
            set;
        }
    }

    //章节节点
    public class Section
    {
       
        //章节标题
        [XmlElementAttribute("Title")]
        public string sectionTitle
        {
            get;
            set;
        }
        //描述
        [XmlElementAttribute("Desc")]
        public string sectionDesc
        {
            get;
            set;
        }
        //章节背景图
        [XmlElementAttribute("BackGroundPic")]
        public string sectionBackGroundPic
        {
            get;
            set;
        }

        [XmlArrayAttribute("Sences")]
        public List<Sence> sences
        {
            get;
            set;
        }
    }


     //关卡节点
    public class Sence
    {
     
   
        //场景标题
        [XmlElementAttribute("Title")]
        public string senceTitle
        {
            get;
            set;
        }

        //场景描述
        [XmlElementAttribute("Desc")]
        public string senceDesc
        {
            get;
            set;
        }

        //场景类型(普通/精英)
        [XmlElementAttribute("Type")]
        public string senceType
        {
            get;
            set;
        }

        //章节背景图id
        [XmlElementAttribute("BackGroundPic")]
        public string senceBackGroundPic
        {
            get;
            set;
        }

        //奖励
        [XmlElementAttribute("Encourage")]
        public SenceEncourage senceEncourage
        {
            get;
            set;
        }

    }
    //关卡奖励
    public class SenceEncourage
    {
        //黄金奖励
        [XmlElementAttribute("gold")]
        public string encourage_gold
        {
            get;
            set;
        }

        //经验奖励
        [XmlElementAttribute("exp")]
        public string encourage_exp
        {
            get;
            set;
        }

        //物品奖励1
        [XmlElementAttribute("item1")]
        public string encourage_item1
        {
            get;
            set;
        }

        //物品奖励2
        [XmlElementAttribute("item2")]
        public string encourage_item2
        {
            get;
            set;
        }

        //物品奖励3
        [XmlElementAttribute("item3")]
        public string encourage_item3
        {
            get;
            set;
        }

    }

    
}
