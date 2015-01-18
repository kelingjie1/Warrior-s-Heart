using UnityEngine;
using System.Collections;

public class Global
{
    
    public static bool alreadySetupWhenAwake = false;
    public static bool alreadySetupWhenStart = false;

    public static Font Arial;
    public static void SceneAwake()
    {
        if (!alreadySetupWhenAwake)
        {
            SetupOnceWhenAwake();
            alreadySetupWhenAwake = true;
        }
        SetupEverySceneWhenAwake();
    }
    public static void SceneStart()
    {
        if (!alreadySetupWhenStart)
        {
            SetupOnceWhenStart();
            alreadySetupWhenStart = true;
        }
        SetupEverySceneWhenStart();
    }

    static void SetupOnceWhenAwake()
    {
        NetworkManager.Instance.useFakeData = true;
        UILabel label=ResourceManager.Load("Prefab/BaseLabel").GetComponent<UILabel>();
        Arial = label.trueTypeFont;
        GameObject.Destroy(label.gameObject);
    }

    static void SetupEverySceneWhenAwake()
    {
        
    }

    static void SetupOnceWhenStart()
    {
        
    }

    static void SetupEverySceneWhenStart()
    {
        DebugPage.CreateDebugButton();
    }

    public static void Update()
    {
        EventManager.Instance.Update();
        NetworkManager.Instance.Update();
    }


    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>


}
