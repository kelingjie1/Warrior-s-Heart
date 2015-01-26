using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

[Serializable]
public class MapData
{
    public float floorHeight;
    public float width;
    public List<AdornmentData> adormentDataList = new List<AdornmentData>();
    public List<WarriorData> warriorDataList = new List<WarriorData>();
}
[Serializable]
public class AnimationInfo
{
    public string name;
    public float duration;
    public AnimationInfo()
    {

    }
    public AnimationInfo(string animationname,float animationduration)
    {
        name = animationname;
        duration = animationduration;
    }
}
[Serializable]
public class WarriorTemplate
{
    public string name;
    public string catogory;
    public string resource;
    public float width;
    public float height;
    public float colliderWidth;
    public float colliderHeight;
    public float colliderCenterX;
    public float colliderCenterY;
    public SerializableDictionary<string, AnimationInfo> animationDic = new SerializableDictionary<string, AnimationInfo>();
    public float hitDelay;
    public string knockbackExpression;
    public string antiKnockbackExpression;
    public string physicalAttackExpression;
    public string physicalDefenceExpression;
    public string magicAttackExpression;
    public string magicDefenceExpression;
    public string attackSpeedExpression;
    public string maxHPExpression;
    public string maxMoveSpeedExpression;
    public string accelerationExpression;
    public string attackDistanceExpression;
    public List<string> skillList = new List<string>();

    
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
    public string template;
    public float x;
    public string path;
    public float guardingDistance;
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
    public float x;
    public float y;
    public float width;
    public float height;
    public AdornmentData()
    {
        x = 100;
        y = 100;
        name = "unname";
        width = 100;
        height = 100;
    }
}

