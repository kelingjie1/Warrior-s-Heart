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
}
