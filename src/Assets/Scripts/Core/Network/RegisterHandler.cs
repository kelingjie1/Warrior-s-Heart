using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using game_proto;

public sealed partial class NetworkManager
{
	private void RegisterAllHandler()
	{
		// 需要在这里注册所有Handler，不然会报找不到Handler的错误
		Debug.Log ("register loginrsp");
        RegisterHandler((int)MessageType.kMsgLoginRsp, LoginServerRspHandler);

        
	}

    void LoginServerRspHandler(int opcode,byte[] data)
    {
        RspPackage response = ProtoManager.Deserialize<RspPackage>(data);
        Debug.Log("LoginServerRsp type:" + Convert.ToString(response.type));
        if (response.type == (int)MessageType.kMsgLoginRsp)
        {
            LoginRsp rsp = ProtoManager.Deserialize<LoginRsp>(response.body);
            EventManager.Instance.SendEvent(EventDefine.LoginServerComplete, 0, rsp);
        }
        else
        {
            Debug.Log("unkown reponse type");
        }
    }

}
