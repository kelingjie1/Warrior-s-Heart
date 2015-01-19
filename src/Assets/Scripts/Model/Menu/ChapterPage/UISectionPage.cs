using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UISectionPage : BasePage 
{
	static UISectionPage m_instance;
	public static UISectionPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/ChapterPage/SectionPage").GetComponent<UISectionPage>();
			}
			return m_instance;
		}
	}

	private List<UISectionEntryPoint> m_setctionLoaded = new List<UISectionEntryPoint>();

	public Section ChapterData
	{
		get {
			return m_chapter;
		}
		set {
			m_chapter = value;

			foreach (UISectionEntryPoint item in m_setctionLoaded)
			{
				Destroy(item.gameObject);
			}
			m_setctionLoaded.Clear();

			//展示关卡,点的绘画
			foreach (Sence section in m_chapter.sections)
			{
				UISectionEntryPoint item = UISectionEntryPoint.Instance;
				gameObject.FindChild("Backgroud").AddChild(item.gameObject);
				m_setctionLoaded.Add(item);
				
				item.gameObject.transform.localPosition = section.Position;
				item.SectionData = section;
				
				UIEventListener.Get (item.gameObject).onClick = OnStartGameClick;
			}
			//gameObject.FindChild ("EnterDialog").GetComponent<UITexture>().mainTexture = FileLoader.LoadTexture("Image 13.png");
		}
	}

	void OnStartGameClick(GameObject go)
	{
		UISectionEntryPoint entry = go.GetComponent<UISectionEntryPoint>();
		UIEntryDialog dialog = UIEntryDialog.Instance;
		dialog.SectionData = entry.SectionData;
		PageManager.Instance.ShowDialog(dialog);
	}

	private Section m_chapter = new Section();
}
