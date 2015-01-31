using UnityEngine;
using System.Collections;
using System;
using ProtoBuf;
using game_proto;

public class FakeDataHandler
{
    public static void RegisterAllFakeDataHandler()
    {
        FakeDataManager.Instance.RegisterRspHandler(typeof(UpdateAppReq), HandleUpdateAppReq);
    }

    public static NetworkManager.NetPacket HandleUpdateAppReq(IExtensible data)
    {
        UpdateAppReq req = data as UpdateAppReq;

        UpdateAppRsp rsp = new UpdateAppRsp();
        return new NetworkManager.NetPacket(false, null, (int)MessageType.kMsgUpdateAppRsp, ProtoManager.Serialize(rsp));
    }
    
}
