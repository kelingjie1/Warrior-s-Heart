﻿using UnityEngine;
using System.Collections;

public class DebugPage : BasePage
{
    public static void CreateDebugButton()
    {
        GameObject button = new GameObject();
        button.layer = 5;
        UILabel label = button.AddComponent<UILabel>();
        label.trueTypeFont = Global.Arial;
        label.text = "DEBUG";
        label.pivot = UIWidget.Pivot.BottomLeft;
        label.depth = 1000;
        NGUITools.AddWidgetCollider(button);
        GameObject topPanel=PageManager.Instance.gameObject.FindChild("TopPanel");
        topPanel.AddChild(button);
        label.transform.localPosition = new Vector3(-Screen.width / 2, -Screen.height / 2, 0);
        UIEventListener.Get(button).onClick = OnDebugButtonClick;
        
    }

    private static void OnDebugButtonClick(GameObject go)
    {
        PageManager.Instance.ShowDialog(DebugPage.Instance);
    }

    static DebugPage m_instance;
    public static DebugPage Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = ResourceManager.LoadGameObject("Prefab/Common/DebugPage").GetComponent<DebugPage>();
            }
            return m_instance;
        }
    }
    void Awake()
    {
        UIEventListener.Get(this.gameObject.FindChild("Title")).onClick = OnTitleClick;
    }

    private void OnTitleClick(GameObject go)
    {
        PageManager.Instance.HideDialog();
    }

    public override void PageWillAppear()
    {
        base.PageWillAppear();
        Time.timeScale = 0;
    }
    public override void PageDidDisappear()
    {
        base.PageDidDisappear();
        Time.timeScale = 1;
    }


}
