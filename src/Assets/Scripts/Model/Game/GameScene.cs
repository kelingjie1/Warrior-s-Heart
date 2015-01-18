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
    void Awake()
    {
        Global.SceneAwake();
    }
	void Start ()
    {
        Global.SceneStart();
        PageManager.Instance.ShowPage(GamePage.Instance);
	}

    void Update()
    {
        Global.Update();
    }
}
