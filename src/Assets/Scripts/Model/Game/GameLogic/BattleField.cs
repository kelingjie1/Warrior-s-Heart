using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

// public delegate void BattleEventDelegate(BattleEventDefine define, List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null);
class EventHandlerComparer : IComparer<BattleEventHandler>
{
    public int Compare(BattleEventHandler x, BattleEventHandler y)
    {
        if (x.priority > y.priority)
        {
            return -1;
        }
        else if (x.priority < y.priority)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
public class BattleField : MonoBehaviour
{
    static BattleField m_instance;
    public static BattleField Instance
    {
        get
        {
            return m_instance;
        }
    }
    public List<Warrior> AttackerList;
    public List<Warrior> DefenderList;
    public List<Ammo> AttackerAmmoList;
    public List<Ammo> DefenderAmmoList;
    public List<GameObject> trashList;

    public int width = 960;
    public int floorHeight;

    void Awake()
    {
        m_instance = this;
    }
    public void AddTrash(GameObject go)
    {
        trashList.Add(go);
        if (trashList.Count>10)
        {
            GameObject trash = trashList[trashList.Count - 1];
            trashList.RemoveAt(trashList.Count - 1);
            GameObject.Destroy(trash);
        }
    }

    UITexture CreateAdorment()
    {
        GameObject go = new GameObject();
        gameObject.AddChild(go);
        go.AddComponent<UITexture>();
        return go.GetComponent<UITexture>();
    }
    void LoadMap()
    {
//         string path = "";
//         XmlDocument doc = new XmlDocument();
//         doc.Load(path);
//         XmlElement root = doc.DocumentElement;
//         XmlElement ele = root.GetElementsByTagName("Width").Item(0) as XmlElement;
//         width = int.Parse(ele.InnerText);
//         ele = root.GetElementsByTagName("FloorHeight").Item(0) as XmlElement;
//         floorHeight = int.Parse(ele.InnerText);
// 
//         XmlElement adornmentNode = root.GetElementsByTagName("Adornment").Item(0) as XmlElement;
//         foreach (XmlElement item in adornmentNode.ChildNodes)
//         {
//             UITexture obj = CreateAdorment();
//             obj.name = item.Name;
//             obj.mainTexture=Resources.Load<Texture>(item.GetAttribute("Image"));
//             obj.transform.localPosition = new Vector3(int.Parse(item.GetAttribute("X")), int.Parse(item.GetAttribute("Y")), 0);
//             obj.width = int.Parse(item.GetAttribute("Width"));
//             obj.height = int.Parse(item.GetAttribute("Height"));
//         }
//         XmlElement warriorNode = root.GetElementsByTagName("Warrior").Item(0) as XmlElement;
//         foreach (XmlElement item in warriorNode.ChildNodes)
//         {
//             Warrior warrior = Warrior.Create();
//             warrior.name = item.Name;
//             warrior.path = item.GetAttribute("WarriorTemplate");
//             if (!warrior.path.Equals(""))
//             {
//                 warrior.template = new WarriorTemplate(warriorDir.Text + "\\" + warrior.path);
//             }
//             warrior.x = int.Parse(item.GetAttribute("X"));
//             warrior.powerPoint = int.Parse(item.GetAttribute("PowerPoint"));
//             warrior.agilityPoint = int.Parse(item.GetAttribute("AgilityPoint"));
//             warrior.strongPoint = int.Parse(item.GetAttribute("StrongPoint"));
//             warrior.intelligencePoint = int.Parse(item.GetAttribute("IntelligencePoint"));
// 
//             warrior.guardingDistance = int.Parse(item.GetAttribute("GuardingDistance"));
//         }

        /////////////////////////////////////////////////////////////////////////////////

        for (int i = 0; i < 2; i++)
        {
            Warrior attacker = Warrior.Create();
            this.gameObject.AddChild(attacker.gameObject);
            attacker.transform.localPosition = new Vector3(50 + i * 20, 82, 0);
            attacker.isAttacker = true;
            attacker.name = "attacker" + i;
            AttackerList.Add(attacker);
        }
        AttackerList[0].TestMelee();
        AttackerList[1].TestRemote();
        for (int i = 0; i < AttackerList.Count; i++)
        {
            for (int j = i + 1; j < AttackerList.Count; j++)
            {
                Physics.IgnoreCollision(AttackerList[i].collider, AttackerList[j].collider);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            Warrior defender = Warrior.Create();
            this.gameObject.AddChild(defender.gameObject);
            defender.transform.localPosition = new Vector3(Screen.width - 50 - i * 20, 82, 0);
            defender.name = "defender" + i;
            DefenderList.Add(defender);
        }
        DefenderList[0].TestMelee();
        DefenderList[1].TestRemote();
        for (int i = 0; i < DefenderList.Count; i++)
        {
            for (int j = i + 1; j < DefenderList.Count; j++)
            {
                Physics.IgnoreCollision(DefenderList[i].collider, DefenderList[j].collider);
            }
        }

        ///////////////////////////////
        foreach (Warrior defender in DefenderList)
        {
            defender.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void StartBattle()
    {
        this.SendEvent(BattleEventType.WillStartBattle);
        //TEST///////////////////////
        LoadMap();
        DidHitHandler_Base didhitbase = new DidHitHandler_Base();
        this.RegisterEvent(BattleEventType.DidHit, didhitbase);
        DidKnockHandler_Base didknockbase = new DidKnockHandler_Base();
        this.RegisterEvent(BattleEventType.DidKnock, didknockbase);
        /////////////////////////
        this.SendEvent(BattleEventType.DidStartBattle);
    }


    //Event
    Dictionary<BattleEventType, OrderedList<BattleEventHandler>> EventDic = new Dictionary<BattleEventType, OrderedList<BattleEventHandler>>();

    public void RegisterEvent(BattleEventType define, BattleEventHandler handler)
    {
        if (!EventDic.ContainsKey(define))
        {
            EventDic.Add(define, new OrderedList<BattleEventHandler>(new EventHandlerComparer()));
        }
        EventDic[define].Add(handler);
    }

    public void UnRegisterEvent(BattleEventType define, BattleEventHandler handler)
    {
        if (!EventDic.ContainsKey(define))
        {
            return;
        }
        EventDic[define].Remove(handler);

    }

    public void SendEvent(BattleEventType define, List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {

        OrderedList<BattleEventHandler> handlerlist;
        try
        {
            handlerlist = EventDic[define];
        }
        catch (System.Exception ex)
        {
            //Debug.Log("NoDelegateRecvThisEvent:" + define.ToString());
            return;
        }
        for (int i = 0; i < handlerlist.Count; i++)
        {
            handlerlist[i].HandleEvent(sponsors, responders, param0, param1, param2, param3);
        }
    }

    void Update()
    {

    }

    void OnClick()
    {
        Debug.Log("aa");
    }

}
