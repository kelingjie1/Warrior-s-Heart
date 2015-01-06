using UnityEngine;
using System.Collections;

public class UIChapterPage : BasePage 
{
	static UIChapterPage m_instance;
	public static UIChapterPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/ChapterPage/ChapterPage").GetComponent<UIChapterPage>();
			}
			return m_instance;
		}
	}
	
	
	void Awake()
	{
		//加载关卡配置，获取关卡数据（包括场景）

		//展示关卡,点的绘画
		for (int i = 0; i < 5; ++i)
		{
			UIChapterEntryPoint item = UIChapterEntryPoint.Instance;
			gameObject.FindChild("WorldMap").AddChild(item.gameObject);

			item.gameObject.transform.localPosition = new Vector3 (-300 + i * 100, -150 + i * 100, 0);

			UIEventListener.Get (item.gameObject).onClick = OnStartGameClick;
		}

		//gameObject.FindChild ("EnterDialog").GetComponent<UITexture>().mainTexture = FileLoader.LoadTexture("Image 13.png");
	}
	
	void OnStartGameClick(GameObject go)
	{
		PageManager.Instance.ShowDialog(UIEntryDialog.Instance);
	}
}
