using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using DG.Tweening;
using System.IO;

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

    public MapData mapData;


    public BoxCollider floorCollider;
    public BoxCollider leftWallCollider;
    public BoxCollider rightWallCollider;
    void Awake()
    {
        m_instance = this;
        floorCollider = gameObject.FindChild("Floor").GetComponent<BoxCollider>();
        leftWallCollider = gameObject.FindChild("LeftWall").GetComponent<BoxCollider>();
        rightWallCollider = gameObject.FindChild("RightWall").GetComponent<BoxCollider>();
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
	public void Pause()
	{
		Time.timeScale = 0;
		foreach (Warrior warrior in AttackerList) 
		{
            warrior.pause = true;
		}

		foreach (Warrior warrior in DefenderList) 
		{
            warrior.pause = true;
		}
	}
    public void JudgeWin()
    {
        if (AttackerList.Count==0)
        {
            PageManager.Instance.ShowDialog(ScorePage.Instance);
			Pause();
        }
        else if (DefenderList.Count==0)
        {
            PageManager.Instance.ShowDialog(ScorePage.Instance);
			Pause();
        }
    }

    public void ShowMessage(string msg, Vector3 position, Color color)
    {
        UILabel label = ResourceManager.Load("Prefab/Game/BattleLabel").GetComponent<UILabel>();
        BattleField.Instance.gameObject.AddChild(label.gameObject);
        label.transform.localPosition = position;
        label.transform.DOLocalMoveY(position.y + 50, 3).OnComplete(() => OnMessageMoveComplete(label));
        label.text = msg;
    }
    private void OnMessageMoveComplete(UILabel label)
    {
        GameObject.Destroy(label.gameObject);
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
        string path = Global.MapPath + "1-1";
        XmlSerializer xs = new XmlSerializer(typeof(MapData));
        FileStream fs = new FileStream(path, FileMode.Open);
        mapData = xs.Deserialize(fs) as MapData;
        fs.Close();
        floorCollider.center = new Vector3(mapData.width / 2, mapData.floorHeight / 2, 0);
        floorCollider.size = new Vector3(mapData.width, mapData.floorHeight, 100);
        leftWallCollider.center = new Vector2(-5, Screen.height / 2);
        rightWallCollider.center = new Vector2(mapData.width + 5, Screen.height / 2);
        foreach (AdornmentData adormentData in mapData.adormentDataList)
        {
            UITexture obj = CreateAdorment();
            obj.name = adormentData.name;
            obj.mainTexture = ResourceManager.LoadTexture(Global.ImagePath + adormentData.image);
            obj.transform.localPosition = new Vector3(adormentData.x, adormentData.y, 0);
            obj.width = (int)adormentData.width;
            obj.height = (int)adormentData.height;
        }
        foreach (WarriorData warriorData in mapData.warriorDataList)
        {
            Warrior warrior = Warrior.Create();
            this.gameObject.AddChild(warrior.gameObject);
            warrior.warriorData = warriorData;
            if (warrior.isAttacker)
            {
                AttackerList.Add(warrior);
            }
            else
            {
                DefenderList.Add(warrior);
            }
        }
        

        /////////////////////////////////////////////////////////////////////////////////


    }
    
    public void StartBattle()
    {
        this.SendEvent(BattleEventType.WillStartBattle);
        //TEST///////////////////////
        LoadMap();

        for (int i = 0; i < AttackerList.Count; i++)
        {
            AttackerList[i].id = i;
            for (int j = i + 1; j < AttackerList.Count; j++)
            {
                Physics.IgnoreCollision(AttackerList[i].collider, AttackerList[j].collider);
            }
        }

        for (int i = 0; i < DefenderList.Count; i++)
        {
            DefenderList[i].id = i;
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

        DidHitHandler_Base didhitbase = new DidHitHandler_Base();
        this.RegisterEvent(BattleEventType.DidHit, didhitbase);
        DidKnockHandler_Base didknockbase = new DidKnockHandler_Base();
        this.RegisterEvent(BattleEventType.DidKnock, didknockbase);
        DidHurtHandler_Base didhurtbase = new DidHurtHandler_Base();
        this.RegisterEvent(BattleEventType.DidHurt, didhurtbase);
        DidKnockWallHandler didknockwall = new DidKnockWallHandler();
        this.RegisterEvent(BattleEventType.DidKnockWall, didknockwall);
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
