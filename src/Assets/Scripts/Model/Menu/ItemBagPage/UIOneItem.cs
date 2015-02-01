using UnityEngine;
using System.Collections;
using game_proto;

//ui 数据结构 用户数据拉取回来以后直接放到这
public class UIOneItem : MonoBehaviour
{
    public UIOneItem()
    {
        m_BagItem = new BagItem();
    }
    //协议数据结构
    public BagItem m_BagItem;
    //maybe other

    public static UIOneItem Instance
    {
        get
        {
            return ResourceManager.LoadGameObject("Prefab/Menu/ItemBagPage/OneItemBag").GetComponent<UIOneItem>();
        }
    }

    void Awake()
    {
        int i = 0;
        i = i + 1;
    }

}