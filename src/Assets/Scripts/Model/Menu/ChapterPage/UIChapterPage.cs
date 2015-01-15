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


		//chapterData
		FileLoader.SaveXml(ChapterDataMgr.m_sConfigFile, ChapterDataMgr.Instance, typeof(ChapterDataMgr));

		foreach (Section chapter in ChapterDataMgr.Instance.chapters)
		{
			Debug.Log(chapter.title);

			UIChapterEntryPoint item = UIChapterEntryPoint.Instance;
			gameObject.FindChild("WorldMap").AddChild(item.gameObject);
			
			item.gameObject.transform.localPosition = chapter.Position;
			item.ChapterData = chapter;

			UIEventListener.Get (item.gameObject).onClick = OnEnterSectionClick;
		}
		//gameObject.FindChild ("EnterDialog").GetComponent<UITexture>().mainTexture = FileLoader.LoadTexture("Image 13.png");
	}
	
	void OnEnterSectionClick(GameObject go)
	{
		UIChapterEntryPoint entry = go.GetComponent<UIChapterEntryPoint>();
		UISectionPage page = UISectionPage.Instance;
		page.ChapterData = entry.ChapterData;
		PageManager.Instance.ShowPage(page);
	}
}
