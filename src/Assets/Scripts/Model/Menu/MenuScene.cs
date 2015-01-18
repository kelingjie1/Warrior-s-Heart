using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour 
{
    void Awake()
    {
        Global.SceneAwake();
    }
	void Start()
	{
        Global.SceneStart();
		PageManager.Instance.ShowPage(UIMainMenuPage.Instance);
	}

    void Update()
    {
        Global.Update();
    }
}
