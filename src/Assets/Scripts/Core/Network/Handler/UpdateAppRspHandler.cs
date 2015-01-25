using System;
using System.Collections;
using game_proto;
using UnityEngine;

public class UpdateAppRspHandler : IPacketHandler
{
	public Int32 GetOpcode()
	{
		return (Int32)MessageType.kMsgUpdateAppRsp;
	}
	
	public void Handle (Byte[] data)
	{
		RspPackage response = ProtoManager.Deserialize<RspPackage> (data);
		Debug.Log ("UpdateAppRsp type:" + Convert.ToString (response.type));
		if (response.type == (int)MessageType.kMsgUpdateAppRsp) {
		    UpdateAppRsp updateAppRsp = ProtoManager.Deserialize<UpdateAppRsp> (response.body);
			EventManager.Instance.SendEvent (EventDefine.UpdateAppComplete, 0, updateAppRsp);
		} else {
			Debug.Log ("unkown reponse type");
		}
	}
}

