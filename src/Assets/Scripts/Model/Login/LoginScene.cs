using UnityEngine;
using System.Collections;

public class LoginScene : MonoBehaviour 
{
    void Awake()
    {
        Global.SceneAwake();
    }
    void Start()
    {
        Global.SceneStart();
        PageManager.Instance.ShowPage(LogoPage.Instance);
    }

    void Update()
    {
        Global.Update();
    }
}
