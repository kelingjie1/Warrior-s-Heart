using UnityEngine;
using System.Collections;

public class WarriorBattlePanel : MonoBehaviour 
{
    public static WarriorBattlePanel Create()
    {
        return ResourceManager.LoadGameObject("Prefab/Game/WarriorBattlePanel").GetComponent<WarriorBattlePanel>();
    }
    public UIProgressBar HPBar;
	void Awake()
    {
        HPBar = gameObject.FindChild("HPBar").GetComponent<UIProgressBar>();
    }

	
}
