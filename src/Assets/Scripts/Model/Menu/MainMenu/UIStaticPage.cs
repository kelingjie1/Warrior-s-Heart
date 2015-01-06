using UnityEngine;
using System.Collections;

public class UIStaticPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake()
	{
		UIEventListener.Get(gameObject.FindChild ("ReturnButton")).onClick = OnReturnButtonClick;
	}
	
	void OnReturnButtonClick(GameObject go)
	{
		PageManager.Instance.ShowPage(UIMainMenuPage.Instance);
	}
}
