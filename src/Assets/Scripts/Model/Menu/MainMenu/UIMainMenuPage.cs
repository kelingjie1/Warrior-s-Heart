using UnityEngine;
using System.Collections;

public class UIMainMenuPage : BasePage 
{
	static UIMainMenuPage m_instance;
	public static UIMainMenuPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/MainMenuPage/MainMenuPage").GetComponent<UIMainMenuPage>();
			}
			return m_instance;
		}
	}
	

	void Awake()
	{
		UIEventListener.Get(gameObject.FindChild ("EnterChapter")).onClick = OnEnterChapterClick;
		UIEventListener.Get(gameObject.FindChild ("EnterShop")).onClick = OnEnterShopClick;
		UIEventListener.Get(gameObject.FindChild ("EnterBarracks")).onClick = OnEnterBarracksClick;
        UIEventListener.Get(gameObject.FindChild("HeroButton")).onClick = OnHeroButtonClick;
	}

    private void OnHeroButtonClick(GameObject go)
    {
        PageManager.Instance.ShowPage(UIBagPage.Instance);
    }

	void OnEnterChapterClick(GameObject go)
	{
		PageManager.Instance.ShowPage(UIChapterPage.Instance);
	}

	void OnEnterShopClick(GameObject go)
	{
		PageManager.Instance.ShowPage(ShopMenuPage.Instance);
	}

	void OnEnterBarracksClick(GameObject go)
	{
		PageManager.Instance.ShowPage(UIBagPage.Instance);
	}
}
