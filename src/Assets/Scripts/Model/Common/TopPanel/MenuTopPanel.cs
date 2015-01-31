using UnityEngine;
using System.Collections;

public class MenuTopPanel : MonoBehaviour 
{
    void Awake()
    {
        UIEventListener.Get(gameObject.FindChild("BackButton")).onClick = OnBackButtonClick;
    }

    private void OnBackButtonClick(GameObject go)
    {
        PageManager.Instance.ShowPage(UIMainMenuPage.Instance, PageManager.AnimationType.LeftToRight);
    }
}
