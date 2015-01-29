using System.Collections;
using System;
using System.Net;
using System.IO;
using System.Threading;
using UnityEngine;

public class DownloadTool
{
	public static DownloadTool StartDownload(string saveFileName, string url, Action<DownloadTool> callbackUpdate)
	{
		DownloadTool download = new DownloadTool(saveFileName, url, callbackUpdate);
		Thread thread = new Thread(new ThreadStart(download.StartDownload));
		thread.Start();
		return download;
	}

	private DownloadTool(string saveFileName, string url, Action<DownloadTool> callbackUpdate)
	{
        Directory.CreateDirectory(Directory.GetParent(saveFileName).FullName);
		SaveFileName = saveFileName;
		DownloadUrl  = url;
		m_updateHandler = callbackUpdate;
		IsDone = false;
		Error = null;
	}

	public void StartDownload()
	{
		long lStartPos = 0;
		FileStream fs;
		if (File.Exists(SaveFileName))
		{
			fs = File.OpenWrite(SaveFileName);
			lStartPos = fs.Length;
			fs.Seek(lStartPos, SeekOrigin.Current);
		}
		else
		{
			fs = new FileStream(SaveFileName, FileMode.Create);
			lStartPos = 0;
		}

		try
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(DownloadUrl);
			if (lStartPos > 0)
			{
				request.AddRange((int)lStartPos);
			}

			Stream net_stream = request.GetResponse().GetResponseStream();
			m_downloadedSize = lStartPos;
			m_totalFileSize = request.GetResponse().ContentLength + m_downloadedSize;
			byte[] nbytes = new byte[1024];
			int nReadSize = 0;
			nReadSize = net_stream.Read(nbytes, 0, 1024);
			while (nReadSize > 0)
			{
				fs.Write(nbytes, 0, nReadSize);
				nReadSize = net_stream.Read(nbytes, 0, 1024);
				m_downloadedSize += nReadSize;
				m_updateHandler(this);
			}
            m_downloadedSize = m_totalFileSize;
            net_stream.Close();
			IsDone = true;
		}
		catch (Exception ex)
		{
			Error = ex.ToString();
            Debug.Log(Error);
			
		}
        finally
        {
            fs.Close();
            m_updateHandler(this);
            
            
        }
	}
	
	public float Percent
	{
		get
		{
			return (float)m_downloadedSize / m_totalFileSize;
		}
	}

	public bool IsDone { get; set; }
	public string Error { get; set; }
	
	public string SaveFileName { get; set; }
	public string DownloadUrl { get; set; }
	
	long m_totalFileSize;
	long m_downloadedSize;
	
	Action<DownloadTool> m_updateHandler;
}


