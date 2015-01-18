using UnityEngine;
using System.Collections;

public class DebugPage : BasePage
{
    public static void CreateDebugButton()
    {
        GameObject button = new GameObject();
        UILabel label = button.AddComponent<UILabel>();
        label.trueTypeFont = ResourceManager.Load("Prefab/BaseLabel").GetComponent<UILabel>().trueTypeFont;
        label.text = "DEBUG";
        label.pivot = UIWidget.Pivot.TopLeft;
        NGUITools.AddWidgetCollider(button);
        GameObject topPanel=PageManager.Instance.gameObject.FindChild("TopPanel");
        topPanel.AddChild(button);
        label.SetAnchor(topPanel);
        label.rightAnchor.relative = 0.9f;
        label.bottomAnchor.relative = 0.9f;
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
                m_instance = ResourceManager.Load("Prefab/DebugPage").GetComponent<DebugPage>();
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
        PageManager.Instance.CloseDialog();
    }


}
