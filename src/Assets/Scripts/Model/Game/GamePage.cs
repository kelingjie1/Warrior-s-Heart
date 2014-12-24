using UnityEngine;
using System.Collections;

public class GamePage : BasePage 
{
    static GamePage m_instance;
    public static GamePage Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = ResourceManager.Load("Prefab/Game/GamePage").GetComponent<GamePage>();
            }
            return m_instance;
        }
    }

    UIScrollView scrollView;
    void Awake()
    {
        scrollView = gameObject.FindChild("ScrollView").GetComponent<UIScrollView>();
        

    }

    private void OnScroll(GameObject go, float delta)
    {
        Debug.Log(delta);
    }
    public override void PageDidAppear()
    {
         
        BattleField.Instance.StartBattle();
    }

    
}
