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
		EventManager.Instance.RegisterEvent (EventDefine.UpdateAppComplete, OnUpdateAppRsp);
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

	public void DownloadResource()
	{		
		UpdateAppReq request = new UpdateAppReq();
		request.app_version  = "1.0";
		request.config_version = "1.0";
		request.resource_version = "1.0";
		// request.Version   = GameInfo.Version;
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

	void OnUpdateAppRsp(EventDefine type, System.Object param, System.Object param2, System.Object param3, System.Object param4)
	{
		UpdateAppRsp response = (UpdateAppRsp)param;
		Debug.Log ("app_version:" + response.app_update_url
		           + " config_verson:" + response.config_url
		           + " resource_version:" + response.resource_url);

		// redirect to app stores
		if (!string.IsNullOrEmpty(response.app_update_url)) 
        {
			// TODO:redirect to app stores
		}

		// download resource files
		if (!string.IsNullOrEmpty(response.resource_url)) {
			string download_path =  Global.DownloadPath + "Resources.zip";
			Debug.Log("save_path:" + download_path);
			DownloadTool.StartDownload(download_path, response.resource_url, OnDownloadCallback);
		}

		// download config files
		if (!string.IsNullOrEmpty(response.config_url)) {
			string download_path =  Global.DownloadPath + "Config.zip";
			Debug.Log("save_path:" + download_path);
			DownloadTool.StartDownload(download_path, response.config_url, OnDownloadCallback);
		}		
	}

	/****************************************************
	 **********  download regin            **************
	 ****************************************************/
	public float DownloadPercent { get; set; }
	public int   DownloadState { get; set; }   // 0:downloading, 1:success, 2:failed
	void OnDownloadCallback(DownloadTool download)
	{
		// Downloading
		DownloadPercent = download.Percent;
		Debug.Log ("download percent:" + DownloadPercent);

		// Donwload is done
		if (download.IsDone)
		{
			// success
			if (null == download.Error)
			{
				// unzip
				Unzip(download.SaveFileName);
				
				// Delete
				File.Delete(download.SaveFileName);
				// Download finish
				DownloadState = 1;
				Debug.Log("finish download resouce and config files");
			}
			else // Failed
			{
				// Delete
				if (File.Exists(download.SaveFileName))
				{
					File.Delete(download.SaveFileName);
				}
				
				DownloadState = 2;
				Debug.LogError(download.Error);
			}
		}
	}

	void Unzip(string filepath)
	{
		if (!File.Exists(filepath))
		{
			UnityEngine.Debug.LogWarning("Can't find the file: " + filepath);
			return;
		}
		
		using (ZipInputStream s = new ZipInputStream(File.OpenRead(filepath)))
		{
			ZipEntry theEntry;
			while ((theEntry = s.GetNextEntry()) != null)
			{
				string directoryName = Global.DownloadPath + Path.GetDirectoryName(theEntry.Name);
				string fileName      = Path.GetFileName(theEntry.Name);
				string fullPath      = directoryName + "/" + fileName;
			
				// create directory
				if (directoryName.Length > 0)
				{
					Directory.CreateDirectory(directoryName);
				}
				
				if (!string.IsNullOrEmpty(fileName))
				{
					using (FileStream streamWriter = File.Create(fullPath))
					{
						int size = 2048;
						byte[] data = new byte[2048];
						while (true)
						{
							size = s.Read(data, 0, data.Length);
							if (size > 0)
							{
								streamWriter.Write(data, 0, size);
							}
							else
							{
								break;
							}
						}
					}
				}
			}
		}
	}
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
