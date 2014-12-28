using System;
using System.Collections;
using game_proto;
using UnityEngine;

public class LoginServerRspHandler : IPacketHandler
{
	public Int32 GetOpcode()
	{
		return (Int32)MessageType.kMsgLoginRsp;
	}

	public void Handle(Byte[] data)
	{
		RspPackage response = ProtoManager.Deserialize<RspPackage>(data);
		Debug.Log("LoginServerRsp type:" + Convert.ToString(response.type));
		EventManager.Instance.SendEvent(EventDefine.LoginServerComplete, 0, response);
	}
}
