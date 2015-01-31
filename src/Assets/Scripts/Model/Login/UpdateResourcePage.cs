using UnityEngine;
using System.Collections;
using game_proto;
using System;
using System.IO;
using System.Threading;

public class UpdateResourcePage : BasePage 
{
    static UpdateResourcePage m_instance;
    public static UpdateResourcePage Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = ResourceManager.LoadGameObject("Prefab/Login/UpdateResourcePage").GetComponent<UpdateResourcePage>();
            }
            return m_instance;
        }
    }


    UILabel ConfigProgressLabel;
    UIProgressBar ConfigProgressBar;
    UILabel ResourceProgressLabel;
    UIProgressBar ResourceProgressBar;

    int downloadPhase;
    void Awake()
    {
        ConfigProgressLabel = gameObject.FindChild("ConfigProgressLabel").GetComponent<UILabel>();
        ConfigProgressBar = gameObject.FindChild("ConfigProgressBar").GetComponent<UIProgressBar>();
        ResourceProgressLabel = gameObject.FindChild("ResourceProgressLabel").GetComponent<UILabel>();
        ResourceProgressBar = gameObject.FindChild("ResourceProgressBar").GetComponent<UIProgressBar>();
    }
    public override void PageWillAppear()
    {
        base.PageWillAppear();
        NetworkManager.Instance.RegisterHandler((int)MessageType.kMsgUpdateAppRsp, UpdateAppRspHandler);
        UpdateAppReq request = new UpdateAppReq();
        request.app_version = "1.0";
        request.config_version = "1.0";
        request.resource_version = "1.0";
        NetworkManager.Instance.Send(request);
    }
    void UpdateAppRspHandler(int opcode, byte[] data)
    {
        RspPackage response = ProtoManager.Deserialize<RspPackage>(data);
        Debug.Log("UpdateAppRsp type:" + Convert.ToString(response.type));
        if (response.type == (int)MessageType.kMsgUpdateAppRsp)
        {
            UpdateAppRsp rsp = ProtoManager.Deserialize<UpdateAppRsp>(response.body);
            Debug.Log("app_version:" + rsp.app_update_url
                   + " config_verson:" + rsp.config_url
                   + " resource_version:" + rsp.resource_url);

            // redirect to app stores
            if (!string.IsNullOrEmpty(rsp.app_update_url))
            {
                // TODO:redirect to app stores
            }

            // download resource files
            if (!string.IsNullOrEmpty(rsp.resource_url))
            {
                string download_path = Global.DownloadPath + "Resources.zip";
                Debug.Log("save_path:" + download_path);
                DownloadTool.StartDownload(download_path, rsp.resource_url, OnResourceDownloadCallback);
            }
            else
            {

            }

            // download config files
            if (!string.IsNullOrEmpty(rsp.config_url))
            {
                string download_path = Global.DownloadPath + "Config.zip";
                Debug.Log("save_path:" + download_path);
                DownloadTool.StartDownload(download_path, rsp.config_url, OnConfigDownloadCallback);
            }	
        }
        else
        {
            Debug.Log("unkown reponse type");
        }
    }

    void OnConfigDownloadCallback(DownloadTool download)
    {
        // Downloading
        EventManager.Instance.Invoke(() => UpdateConfig(download.Percent));
        if (download.IsDone)
        {
            // success
            if (null == download.Error)
            {
                Util.Unzip(download.SaveFileName);
                File.Delete(download.SaveFileName);
                downloadPhase++;
                if (downloadPhase>=2)
                {
                    EventManager.Instance.Invoke(DownloadFinish);
                }

            }
            else // Failed
            {
                Debug.Log("下载失败");
                // Delete
                if (File.Exists(download.SaveFileName))
                {
                    File.Delete(download.SaveFileName);
                }

                Debug.LogError(download.Error);
            }
        }
    }
    void OnResourceDownloadCallback(DownloadTool download)
    {
        // Downloading
        EventManager.Instance.Invoke(() => UpdateResource(download.Percent));
        if (download.IsDone)
        {
            // success
            if (null == download.Error)
            {
                Util.Unzip(download.SaveFileName);
                File.Delete(download.SaveFileName);
                downloadPhase++;
                if (downloadPhase >= 2)
                {
                    EventManager.Instance.Invoke(DownloadFinish);
                }
            }
            else // Failed
            {
                Debug.Log("下载失败");
                if (File.Exists(download.SaveFileName))
                {
                    File.Delete(download.SaveFileName);
                }

                Debug.LogError(download.Error);
            }
        }
    }
    void UpdateConfig(float progress)
    {
        ConfigProgressLabel.text = (int)(progress * 100) + "%";
        ConfigProgressBar.value = progress;
    }
    void UpdateResource(float progress)
    {
        ResourceProgressLabel.text = (int)(progress * 100) + "%";
        ResourceProgressBar.value = progress;
    }
    public override void PageWillDisappear()
    {
        base.PageWillDisappear();
        NetworkManager.Instance.UnRegisterHandler((int)MessageType.kMsgUpdateAppRsp, UpdateAppRspHandler);
    }
    void DownloadFinish()
    {
        PageManager.Instance.HideDialog();
    }
}
