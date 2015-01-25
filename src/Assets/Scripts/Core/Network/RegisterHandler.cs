using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public sealed partial class NetworkManager
{
	private void RegisterAllHandler()
	{
		// 需要在这里注册所有Handler，不然会报找不到Handler的错误
		Debug.Log ("register loginrsp");
		RegisterHandler (new LoginServerRspHandler());

		Debug.Log ("register updateapprsp");
		RegisterHandler (new UpdateAppRspHandler());
	}
}
