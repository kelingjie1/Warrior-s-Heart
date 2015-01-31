using UnityEngine;
using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using game_proto;

public class LoginModel
{
	private void Init()
	{
        NetworkManager.Instance.RegisterHandler((int)MessageType.kMsgLoginRsp, LoginServerRspHandler);
		EventManager.Instance.RegisterEvent(EventDefine.ErrorCodeReply, OnErrorCodeReply);
	}


	/************************************************************
	 ************       logic functions    **********************
	 ************************************************************/
	public void LoginToServer()
	{	
		LoginReq request = new LoginReq();
		request.channel = (int)LoginChannel.kChannelTypeQQ;
		request.device = SystemInfo.deviceUniqueIdentifier;
		request.token  = "hello";
		NetworkManager.Instance.Send(request);
	}


	/************************************************************
	 ************       event callback    ***********************
	 ************************************************************/

    void LoginServerRspHandler(int opcode, byte[] data)
    {
        RspPackage response = ProtoManager.Deserialize<RspPackage>(data);
        LoginRsp rsp = ProtoManager.Deserialize<LoginRsp>(response.body);
        Debug.Log("LoginServerRsp type:" + Convert.ToString(response.type));
        Debug.Log("login user_id:" + rsp.uid + " session_key:" + rsp.session_key);
        Application.LoadLevel("Menu");
    }

	void OnErrorCodeReply(EventDefine type, System.Object param, System.Object param2, System.Object param3, System.Object param4)
	{
		Debug.Log ("OnErrorReply");
	}


	/****************************************************
	 **********  download regin            **************
	 ****************************************************/
	public float DownloadPercent { get; set; }
	public int   DownloadState { get; set; }   // 0:downloading, 1:success, 2:failed
	

	/****************************************************
	 **********     end regin              **************
	 ****************************************************/
	
	// Instance
	private LoginModel() { Init(); }
	private static LoginModel sInstance = null;
	public static LoginModel Instance
	{
		get
		{
			if (null == sInstance)
			{
				sInstance = new LoginModel();
			}
			
			return sInstance;
		}
	}
}
