using UnityEngine;
using System.Collections;
using game_proto;
using System;
using System.IO;
using System.Threading;
using BestHTTP;
using BestHTTP.Caching;
using System.Collections.Generic;
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
    FileStream resourceStream;
    FileStream configStream;

    int downloadPhase;
    void Awake()
    {
        ConfigProgressLabel = gameObject.FindChild("ConfigProgressLabel").GetComponent<UILabel>();
        ConfigProgressBar = gameObject.FindChild("ConfigProgressBar").GetComponent<UIProgressBar>();
        ResourceProgressLabel = gameObject.FindChild("ResourceProgressLabel").GetComponent<UILabel>();
        ResourceProgressBar = gameObject.FindChild("ResourceProgressBar").GetComponent<UIProgressBar>();
    }
    public override void PageDidAppear()
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
                HTTPRequest request = new HTTPRequest(new Uri(rsp.resource_url), ResourceDownloadFinish);
                resourceStream = File.OpenWrite(Global.TempPath + "Resources.zip");
                request.SetRangeHeader((int)resourceStream.Length);
                request.OnProgress = ResourceDownloadProgress;
                request.UseStreaming = true;
                request.StreamFragmentSize = 1024*100;
                
                HTTPManager.SendRequest(request);
            }
            else
            {
                downloadPhase++;
            }

            // download config files
            if (!string.IsNullOrEmpty(rsp.config_url))
            {
                HTTPRequest request = new HTTPRequest(new Uri(rsp.config_url), ConfigDownloadFinish);
                configStream = File.OpenWrite(Global.TempPath + "Config.zip");
                request.SetRangeHeader((int)configStream.Length);
                request.OnProgress = ConfigDownloadProgress;
                request.UseStreaming = true;
                request.StreamFragmentSize = 1024 * 100;
                HTTPManager.SendRequest(request);
                
            }	
            else
            {
                downloadPhase++;
            }
        }
        else
        {
            Debug.Log("unkown reponse type");
        }
    }
    void ResourceDownloadProgress(HTTPRequest request, int downloaded, int length)
    {
        ResourceProgressLabel.text = downloaded / 1000 + "K/" + length / 1000 + "K";
        ResourceProgressBar.value = downloaded / (float)length;
    }
    void ResourceDownloadFinish(HTTPRequest req, HTTPResponse resp)
    {
        if (resp == null)
        {
            return;
        }

        List<byte[]> list = resp.GetStreamedFragments();
        if (list != null)
        {
            if (list.Count != 1 || list[0].Length != 1)
            {
                foreach (byte[] data in list)
                {
                    resourceStream.Write(data, 0, data.Length);
                }
            }
        }
        if (resp.IsStreamingFinished)
        {
            resourceStream.Close();
            Util.Unzip(Global.TempPath + "Resources.zip", Global.DownloadPath);
            EventManager.Instance.Invoke(DownloadFinish);
        }
        
    }

    void ConfigDownloadProgress(HTTPRequest request, int downloaded, int length)
    {
        ConfigProgressLabel.text = downloaded / 1000 + "K/" + length / 1000 + "K";
        ConfigProgressBar.value = downloaded / (float)length;
    }

    void ConfigDownloadFinish(HTTPRequest req, HTTPResponse resp)
    {
        if (resp == null)
        {
            return;
        }

        List<byte[]> list = resp.GetStreamedFragments();
        if (list != null)
        {
            if (list.Count != 1 || list[0].Length != 1)
            {
                foreach (byte[] data in list)
                {
                    configStream.Write(data, 0, data.Length);
                }
            }
        }
        if (resp.IsStreamingFinished)
        {
            configStream.Close();
            Util.Unzip(Global.TempPath + "Config.zip", Global.DownloadPath);
            EventManager.Instance.Invoke(DownloadFinish);
        }

    }
    
    public override void PageWillDisappear()
    {
        base.PageWillDisappear();
        NetworkManager.Instance.UnRegisterHandler((int)MessageType.kMsgUpdateAppRsp, UpdateAppRspHandler);
    }
    public override void PageDidDisappear()
    {
        base.PageDidDisappear();
        GameObject.Destroy(this.gameObject);
    }
    void DownloadFinish()
    {
        
        downloadPhase++;
        Debug.Log("DownloadFinish:" + downloadPhase);
        if (downloadPhase >= 2)
        {
            PageManager.Instance.HideDialog(PageManager.AnimationType.MiddleZoomOut);
        }
        
    }
}
