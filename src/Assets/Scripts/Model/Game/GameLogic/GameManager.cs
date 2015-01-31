using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using game_proto;

public class FightInfo
{
    public List<WarriorItem> warriorItemList;
    public string mapName;
}
public class BattleResult
{
    
}
public class GameManager 
{
    static GameManager m_instance;
    public static GameManager Instance
    {
        get
        {
            if (m_instance==null)
            {
                m_instance = new GameManager();
            }
            return m_instance;
        }
    }

    GameManager()
    {
        warriorItemList = new List<WarriorItem>();
        WarriorItem warriorItem = new WarriorItem();
        warriorItem.name = "0";
        warriorItem.ref_id = "Fighter";
        warriorItem.power_grow = 1;
        warriorItem.agility_grow = 1;
        warriorItem.strong_grow = 1;
        warriorItem.intelligence_grow = 1;
        warriorItem.power_point = 0;
        warriorItem.agility_point = 0;
        warriorItem.strong_point = 0;
        warriorItem.intelligence_point = 0;
        warriorItemList.Add(warriorItem);

        warriorItem = new WarriorItem();
        warriorItem.name = "1";
        warriorItem.ref_id = "Fighter";
        warriorItem.power_grow = 1;
        warriorItem.agility_grow = 1;
        warriorItem.strong_grow = 1;
        warriorItem.intelligence_grow = 1;
        warriorItem.power_point = 0;
        warriorItem.agility_point = 0;
        warriorItem.strong_point = 0;
        warriorItem.intelligence_point = 0;
        warriorItemList.Add(warriorItem);

        warriorItem = new WarriorItem();
        warriorItem.name = "2";
        warriorItem.ref_id = "Archer";
        warriorItem.power_grow = 1;
        warriorItem.agility_grow = 1;
        warriorItem.strong_grow = 1;
        warriorItem.intelligence_grow = 1;
        warriorItem.power_point = 0;
        warriorItem.agility_point = 0;
        warriorItem.strong_point = 0;
        warriorItem.intelligence_point = 0;
        warriorItemList.Add(warriorItem);

        mapList = new List<string>() { "1-1", "1-2" };
    }

    public int currentFight;
    public List<string> mapList = new List<string>();
    public List<WarriorItem> warriorItemList = new List<WarriorItem>();
    public BattleResult battleResult;
    public void SetBattleInfo(List<WarriorItem> warriorItems,List<string> mapNames)
    {
        mapList = mapNames;
        warriorItemList = warriorItems;
    }

    public void FightEnd(BattleResult result)
    {
        currentFight++;
        if (currentFight>=mapList.Count)
        {
            BattleEnd(result);
        }
        else
        {
            Application.LoadLevel("Game");
        }
    }

    public void BattleEnd(BattleResult result)
    {
        battleResult = result;
        PageManager.Instance.ShowPage(ScorePage.Instance);
    }
    

    public void StartBattle()
    {
        Application.LoadLevel("Game");
    }

    public FightInfo GetCurrentFightInfo()
    {
        FightInfo info = new FightInfo();
        if (mapList.Count==0)
        {
            List<WarriorItem> itemList = new List<WarriorItem>();
            WarriorItem warriorItem = new WarriorItem();
            warriorItem.name = "0";
            warriorItem.ref_id = "Fighter";
            warriorItem.power_grow = 1;
            warriorItem.agility_grow = 1;
            warriorItem.strong_grow = 1;
            warriorItem.intelligence_grow = 1;
            warriorItem.power_point = 0;
            warriorItem.agility_point = 0;
            warriorItem.strong_point = 0;
            warriorItem.intelligence_point = 0;
            itemList.Add(warriorItem);


            warriorItem = new WarriorItem();
            warriorItem.name = "1";
            warriorItem.ref_id = "Fighter";
            warriorItem.power_grow = 1;
            warriorItem.agility_grow = 1;
            warriorItem.strong_grow = 1;
            warriorItem.intelligence_grow = 1;
            warriorItem.power_point = 0;
            warriorItem.agility_point = 0;
            warriorItem.strong_point = 0;
            warriorItem.intelligence_point = 0;
            itemList.Add(warriorItem);

            warriorItem = new WarriorItem();
            warriorItem.name = "2";
            warriorItem.ref_id = "Archer";
            warriorItem.power_grow = 1;
            warriorItem.agility_grow = 1;
            warriorItem.strong_grow = 1;
            warriorItem.intelligence_grow = 1;
            warriorItem.power_point = 0;
            warriorItem.agility_point = 0;
            warriorItem.strong_point = 0;
            warriorItem.intelligence_point = 0;
            itemList.Add(warriorItem);

            info.warriorItemList = itemList;
            info.mapName = "1-2";
        }
        else
        {
            info.warriorItemList = warriorItemList;
            info.mapName = mapList[currentFight];
        }
        
        
        return info;
    }
}
