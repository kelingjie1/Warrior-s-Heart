using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour 
{
	void Start()
	{
		PageManager.Instance.ShowPage(UIChapterPage.Instance);
	}

    void Update()
    {
        EventManager.Instance.Update();
    }
}
