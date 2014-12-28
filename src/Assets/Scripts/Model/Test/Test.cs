using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Test : MonoBehaviour 
{
	void Start () 
    {
        UIEventListener.Get(this.gameObject.FindChild("button")).onClick = OnButtonClick;
	}

    private void OnButtonClick(GameObject go)
    {
        UISprite sprite = go.GetComponent<UISprite>();
        Debug.Log(Application.streamingAssetsPath);
        WWW www = new WWW("file://D:/Warrior-s-Heart/UserStorage/Download/Resources/Animation/Fighter.assetbundle");
        Debug.Log(www.assetBundle);
        Object obj = Instantiate(www.assetBundle.Load("Fighter",System.Type.GetType("UIAtlas")));
        Debug.Log(obj);
        sprite.atlas = obj as UIAtlas;
        sprite.spriteName = "attack_00000";
    }


}
