using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace masterEdit.masterxmldata
{

    public class innerCategory
    {
        public string categoryname;
        public List<innerMaster> innerMasterList = new List<innerMaster>();
    }

    public class innerCategoryList
    {
        public List<innerCategory> categorylist = new List<innerCategory>();
    }

    public class innerMaster
    {
        public string name;
        public Master master = new Master();
    }

    [XmlRootAttribute("master", Namespace = "abc.abc", IsNullable = false)]

    public class Master
    {

        [XmlElementAttribute("Category")]
        public string Category
        {
            get;
            set;
        }

        [XmlElementAttribute("Level")]
        public string Level
        {
            get;
            set;
        }
        
        [XmlElementAttribute("BasicAttr")]
        public basicAttr BasicAttr
        {
            get;
            set;
        }
       
        [XmlElementAttribute("OtherAttr")]
        public otherAttr OtherAttr
        {
            get;
            set;
        }
    }

    public class basicAttr
    {
        [XmlElementAttribute("Power")]
        public string Power
        {
            get;
            set;
        }
        [XmlElementAttribute("Strong")]
        public string Strong
        {
            get;
            set;
        }

        [XmlElementAttribute("Intelligence")]
        public string Intelligence
        {
            get;
            set;
        }

        [XmlElementAttribute("Agility")]
        public string Agility
        {
            get;
            set;
        }

        [XmlElementAttribute("PowerGrow")]
        public string PowerGrow
        {
            get;
            set;
        }
        [XmlElementAttribute("StrongGrow")]
        public string StrongGrow
        {
            get;
            set;
        }
        [XmlElementAttribute("IntelligenceGrow")]
        public string IntelligenceGrow
        {
            get;
            set;
        }
        [XmlElementAttribute("AgilityGrow")]
        public string AgilityGrow
        {
            get;
            set;
        }
    }

    public class otherAttr
    {
        [XmlElementAttribute("HitDelay")]
        public string HitDelay
        {
            get;
            set;
        }

        [XmlElementAttribute("Collide")]
        public Collide collide
        {
            get;
            set;
        }

        [XmlElementAttribute("PicInfo")]
        public PicInfo picInfo
        {
            get;
            set;
        }
    }

    public class PicInfo
    {
        [XmlElementAttribute("PicPath")]
        public string PicPath
        {
            get;
            set;
        }
        [XmlElementAttribute("PicXSize")]
        public string PicXSize
        {
            get;
            set;
        }
        [XmlElementAttribute("PicYSize")]
        public string PicYSize
        {
            get;
            set;
        }
    }

    public class Collide
    {
        [XmlElementAttribute("MinX")]
        public string MinX
        {
            get;
            set;
        }

        [XmlElementAttribute("MaxX")]
        public string MaxX
        {
            get;
            set;
        }

        [XmlElementAttribute("MinY")]
        public string MinY
        {
            get;
            set;
        }

        [XmlElementAttribute("MaxY")]
        public string MaxY
        {
            get;
            set;
        }
    }
}
