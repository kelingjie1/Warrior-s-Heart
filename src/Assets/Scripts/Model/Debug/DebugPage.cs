using UnityEngine;
using System.Collections;

public class DebugPage : BasePage
{
    public static void CreateDebugButton()
    {
        return;
        /*
        GameObject button = new GameObject();
        UILabel label = button.AddComponent<UILabel>();
        label.text = "DEBUG";
        label.trueTypeFont = Resources
        label.pivot = UIWidget.Pivot.TopLeft;
        NGUITools.AddWidgetCollider(button);
        PageManager.Instance.gameObject.AddChild(button);
        UIEventListener.Get(button).onClick = OnDebugButtonClick;
         */
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
        PageManager.Instance.HideDialog();
    }


}
