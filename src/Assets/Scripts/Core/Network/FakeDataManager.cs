using UnityEngine;
using System.Collections;
using game_proto;
using ProtoBuf;

public class FakeDataManager 
{
    static FakeDataManager m_instance;
    public static FakeDataManager Instance
    {
        get
        {
            if (m_instance==null)
            {
                m_instance = new FakeDataManager();
            }
            return m_instance;
        }
    }

    public void GetFakeDataAsync(IExtensible packet)
    {
        Debug.Log(packet.GetType());
    }
}
