using System;

public sealed partial class NetworkManager
{
	private void RegisterAllHandler()
	{
		// 需要在这里注册所有Handler，不然会报找不到Handler的错误
		RegisterHandler(new LoginServerRspHandler());

	}
}
