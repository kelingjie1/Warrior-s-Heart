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
        if (scrollView.transform.localPosition.x < -480 - BattleField.Instance.width)
        {
            scrollView.transform.localPosition = new Vector3(-480 - BattleField.Instance.width, -320, 0);
        }
        if (scrollView.transform.localPosition.x > -480)
        {
            scrollView.transform.localPosition = new Vector3(-480, -320, 0);
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
