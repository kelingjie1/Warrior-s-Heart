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
		EventManager.Instance.RegisterEvent (EventDefine.UpdateAppComplete, OnUpdateAppRsp);
	}

	/************************************************************
	 ************       logic functions    **********************
	 ************************************************************/
	public void LoginToServer()
	{	
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

	public void DownloadResource()
	{
		// header
		ReqHeader header = new ReqHeader ();
		header.mobile_info = SystemInfo.operatingSystem;
		
		// body
		UpdateAppReq request = new UpdateAppReq();
		request.app_version  = "1.0";
		request.config_version = "1.0";
		request.resource_version = "1.0";

		// package
		ReqPackage package = new ReqPackage ();
		package.header = header;
		package.body = ProtoManager.Serialize (request);
		package.type = (int)MessageType.kMsgUpdateAppReq;
		
		byte[] buffer = ProtoManager.Serialize (package);
		// request.Version   = GameInfo.Version;
		NetworkManager.Instance.Send(buffer);
	}

	/************************************************************
	 ************       event callback    ***********************
	 ************************************************************/
	void OnLoginServerSuccess(EventDefine type, System.Object param, System.Object param2, System.Object param3, System.Object param4)
	{
		EventManager.Instance.UnRegisterEvent(EventDefine.ErrorCodeReply, OnErrorCodeReply);
		Application.LoadLevel("Menu");
	}

	void OnErrorCodeReply(EventDefine type, System.Object param, System.Object param2, System.Object param3, System.Object param4)
	{
		Debug.Log ("OnErrorReply");
	}

	void OnUpdateAppRsp(EventDefine type, System.Object param, System.Object param2, System.Object param3, System.Object param4)
	{
		UpdateAppRsp response = (UpdateAppRsp)param;
		Debug.Log ("app_version:" + response.app_update_url
		           + " config_verson:" + response.config_url
		           + " resource_version:" + response.resource_url);

		if (!string.IsNullOrEmpty(response.app_update_url)) 
        {
		    // redirect to app stores
		}

		if (!string.IsNullOrEmpty(response.resource_url)) {
		
		}

		if (!string.IsNullOrEmpty(response.config_url)) {
		
		}
	}
	
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
