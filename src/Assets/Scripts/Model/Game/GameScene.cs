using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using game_proto;

public class GameScene : MonoBehaviour 
{
    public static void StartGame(string mapName,List<WarriorItem> warriorItem)
    {
        Application.LoadLevel("Game");
    }
	void Start ()
    {
        PageManager.Instance.ShowPage(GamePage.Instance);
	}

    void Update()
    {
        EventManager.Instance.Update();
    }
}
