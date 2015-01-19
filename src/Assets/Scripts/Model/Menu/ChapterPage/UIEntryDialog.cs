using UnityEngine;
using System.Collections;

public class UIEntryDialog : BasePage {

	public static UIEntryDialog Instance
	{
		get
		{
			return ResourceManager.Load("Prefab/Menu/ChapterPage/EntryDialog").GetComponent<UIEntryDialog>();
		}
	}

	void Awake()
	{
		UIEventListener.Get (gameObject.FindChild("EnterButton")).onClick = OnStartGameClick;
		UIEventListener.Get (gameObject.FindChild("CloseDialog")).onClick = OnCloseDialogClick;
	}

	void OnStartGameClick(GameObject go)
	{
		Application.LoadLevel("Game");
	}

	void OnCloseDialogClick(GameObject go)
	{
		PageManager.Instance.CloseDialog();
	}

	public Sence SectionData
	{
		get {
			return m_section;
		}
		set {
			m_section = value;

			gameObject.FindChild("ChapterName").GetComponent<UILabel>().text = m_section.title;
			gameObject.FindChild("ChapterDifficulty").GetComponent<UILabel>().text = m_section.type;
		}
	}

	private Sence m_section= new Sence();
}
