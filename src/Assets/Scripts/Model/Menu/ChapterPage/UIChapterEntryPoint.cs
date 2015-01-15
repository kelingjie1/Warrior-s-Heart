using UnityEngine;
using System.Collections;

public class UIChapterEntryPoint : MonoBehaviour {

	public static UIChapterEntryPoint Instance
	{
		get
		{
			return ResourceManager.Load("Prefab/Menu/ChapterPage/ChapterEntryPoint").GetComponent<UIChapterEntryPoint>();
		}
	}

	public Section ChapterData
	{
		get {
			return m_chapter;
		}
		set {
			m_chapter = value;
			gameObject.FindChild("ChapterName").GetComponent<UILabel>().text = m_chapter.title;
		}
	}

	private Section m_chapter = new Section();
}
