using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NCalc;

public class Test : MonoBehaviour 
{
	void Start () 
    {
        UIEventListener.Get(this.gameObject.FindChild("button")).onClick = OnButtonClick;
	}

    private void OnButtonClick(GameObject go)
    {
        Expression e = new Expression("10+15*2");
        Debug.Log(e.Evaluate());
    }


}
