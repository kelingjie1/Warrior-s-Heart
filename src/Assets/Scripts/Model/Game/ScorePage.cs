using UnityEngine;
using System.Collections;

public class ScorePage : BasePage 
{
    static ScorePage m_instance;
    public static ScorePage Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = ResourceManager.LoadGameObject("Prefab/Game/ScorePage").GetComponent<ScorePage>();
            }
            return m_instance;
        }
    }
}
