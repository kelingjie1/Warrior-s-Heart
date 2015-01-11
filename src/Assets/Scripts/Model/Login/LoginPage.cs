using UnityEngine;
using System.Collections;

public class LoginPage : BasePage 
{
    static LoginPage m_instance;
    public static LoginPage Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = ResourceManager.Load("Prefab/Login/LoginPage").GetComponent<LoginPage>();
            }
            return m_instance;
        }
    }

    void Awake()
    {
        UIEventListener.Get(this.gameObject.FindChild("QQLoginButton")).onClick = OnQQLoginButtonClick;
        UIEventListener.Get(this.gameObject.FindChild("WXLoginButton")).onClick = OnWXLoginButtonClick;
    }

	void Start()
	{
		LoginModel.Instance.DownloadResource ();
	}

	// Event
    void OnQQLoginButtonClick(GameObject go)
    {	
		LoginModel.Instance.DownloadResource ();
    }

    void OnWXLoginButtonClick(GameObject go)
    {
        Application.LoadLevel("Menu");
    }
}
