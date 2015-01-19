using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

[Serializable]
public class MapData
{
    public int floorHeight;
    public int width;
    public List<AdornmentData> adormentDataList = new List<AdornmentData>();
    public List<WarriorData> warriorDataList = new List<WarriorData>();
}
[Serializable]
public class AnimationInfo
{
    public string name;
    public float duration;
}
[Serializable]
public class WarriorTemplate
{
    public string name;
    public string catogory;
    public string imageName;
    public int width;
    public int height;
    public int colliderWidth;
    public int colliderHeight;
    public int colliderCenterX;
    public int colliderCentY;
    public SerializableDictionary<string, AnimationInfo> animationDic = new SerializableDictionary<string, AnimationInfo>();
}
public class ObjDataBase
{
    public bool locked;
}
[Serializable]
public class WarriorData : ObjDataBase
{
    public string name;
    public bool isAttacker;
    public WarriorTemplate template;
    public int x;
    public string path;
    public int guardingDistance;
    public int powerPoint;
    public int agilityPoint;
    public int strongPoint;
    public int intelligencePoint;
    public WarriorData()
    {
        name = "unname";
        x = 100;
    }
}
[Serializable]
public class AdornmentData : ObjDataBase
{
    public string name;
    public string image;
    public int x;
    public int y;
    public int width;
    public int height;
    public AdornmentData()
    {
        x = 100;
        y = 100;
        name = "unname";
        width = 100;
        height = 100;
    }
}

