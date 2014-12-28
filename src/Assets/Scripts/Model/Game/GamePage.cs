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

    UIPanel scrollView;
    void Awake()
    {
        scrollView = gameObject.FindChild("ScrollView").GetComponent<UIPanel>();

    }
    void Update()
    {
        if (scrollView.transform.localPosition.x < Screen.width/2 - BattleField.Instance.width)
        {
            scrollView.transform.localPosition = new Vector3(Screen.width / 2 - BattleField.Instance.width, -Screen.height/2, 0);
        }
        if (scrollView.transform.localPosition.x > -Screen.width/2)
        {
            scrollView.transform.localPosition = new Vector3(-Screen.width / 2, -Screen.height/2, 0);
        }
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
