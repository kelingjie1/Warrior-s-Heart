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
		EventManager.Instance.RegisterEvent(EventDefine.LoginServerComplete, OnLoginServerSuccess);
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
	void OnLoginServerSuccess(EventDefine type, System.Object param, System.Object param2, System.Object param3, System.Object param4)
	{
		EventManager.Instance.UnRegisterEvent(EventDefine.ErrorCodeReply, OnErrorCodeReply);
		LoginRsp response = (LoginRsp)param;
		Debug.Log ("login user_id:" + response.uid + " session_key:" + response.session_key);
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
