using UnityEngine;
using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
// using ICSharpCode.SharpZipLib.Zip;
// using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using game_proto;

public class LoginModel
{
	private void Init()
	{
		EventManager.Instance.RegisterEvent(EventDefine.LoginServerComplete, OnLoginServerSuccess);
		EventManager.Instance.RegisterEvent(EventDefine.ErrorCodeReply, OnErrorCodeReply);
	}

	// functions
	public void LoginToServer()
	{	
		string url = "http://42.96.170.192:8080/app/service";
		NetworkManager.Instance.SetServerUrl(url);

		// header
		ReqHeader header = new ReqHeader ();
		header.mobile_info = SystemInfo.operatingSystem;

		// body
		LoginReq request = new LoginReq();
		request.channel = (int)LoginChannel.kChannelTypeQQ;
		request.device = SystemInfo.deviceUniqueIdentifier;

		// package
		ReqPackage package = new ReqPackage ();
		package.header = header;
		package.body = ProtoManager.Serialize (request);
		package.type = (int)MessageType.kMsgLoginReq;

		byte[] buffer = ProtoManager.Serialize (package);
		// request.Version   = GameInfo.Version;
		NetworkManager.Instance.Send(buffer);
	}

	// event
	void OnLoginServerSuccess(EventDefine type, System.Object param, System.Object param2, System.Object param3, System.Object param4)
	{
		EventManager.Instance.UnRegisterEvent(EventDefine.ErrorCodeReply, OnErrorCodeReply);
		Application.LoadLevel("Menu");
	}

	void OnErrorCodeReply(EventDefine type, System.Object param, System.Object param2, System.Object param3, System.Object param4)
	{
		Debug.Log ("OnErrorReply");
	}
	
	// Instance
	private LoginModel() { Init(); }
	private static LoginModel sInstance = null;
	public static LoginModel instance
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
