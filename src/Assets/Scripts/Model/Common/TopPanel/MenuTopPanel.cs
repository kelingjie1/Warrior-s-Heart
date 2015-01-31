using UnityEngine;
using System.Collections;

public class MenuTopPanel : MonoBehaviour 
{
    GameObject RightBar;
    void Awake()
    {
        RightBar = gameObject.FindChild("RightBar");
        UIEventListener.Get(gameObject.FindChild("BackButton")).onClick = OnBackButtonClick;
        UIEventListener.Get(gameObject.FindChild("BarButton")).onClick = OnBarButtonClick;
        UIEventListener.Get(gameObject.FindChild("HeroButton")).onClick = OnHeroButtonClick;
    }

    private void OnBarButtonClick(GameObject go)
    {
        RightBar.SetActive(!RightBar.activeSelf);
    }

    private void OnBackButtonClick(GameObject go)
    {
        PageManager.Instance.ShowPage(UIMainMenuPage.Instance, PageManager.AnimationType.LeftToRight);
    }

    private void OnHeroButtonClick(GameObject go)
    {
        PageManager.Instance.ShowPage(UIBagPage.Instance);
    }

}
