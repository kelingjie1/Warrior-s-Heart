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
}
