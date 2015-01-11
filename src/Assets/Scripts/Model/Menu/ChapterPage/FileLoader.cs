using UnityEngine;
using System.Collections;
using System.IO;

using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System;

public class FileLoader{

	private static string GetFilePath(string name)
	{
		/*if (Application.platform == RuntimePlatform.WindowsEditor 
		    || Application.platform == RuntimePlatform .WindowsPlayer)
		{
			return Application.dataPath + @"/" + name;
		}
		else
		{
			return Application.persistentDataPath + @"/" + name;
		}*/
		return Config.BaseDataPath + name;
	}

	public static Texture2D LoadTexture(string name)
	{
		string filePath = GetFilePath(name);

		FileStream fs = new FileStream(filePath,FileMode.Open,FileAccess.Read);
		System.Drawing.Image img = System.Drawing.Image.FromStream(fs);

		Debug.Log("load img:" + filePath);
		
		MemoryStream ms = new MemoryStream();
		img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

		Debug.Log("Array img");

		Texture2D _tex2 = new Texture2D(1280, 1280);
		_tex2.LoadImage(ms.ToArray());

		return _tex2;
	}

	public static object LoadXML(string name, Type type)   
	{   
		return XmlSerializer.LoadFromXml(GetFilePath(name), type); 
	}

	public static void SaveXml(string name, object pObject, Type type)
	{    
		XmlSerializer.SaveToXml(GetFilePath(name), pObject, type);
	}
}

public static class XmlSerializer
{
	public static void SaveToXml(string filePath, object sourceObj, Type type)
	{
		if (filePath != null && sourceObj != null)
		{
			type = type != null ? type : sourceObj.GetType();
			
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				System.Xml.Serialization.XmlSerializer xmlSerializer 
					= new System.Xml.Serialization.XmlSerializer(type);

				xmlSerializer.Serialize(writer, sourceObj);
			}
		}
	}
	
	public static object LoadFromXml(string filePath, Type type)
	{
		object result = null;
		
		try
		{
			if (File.Exists(filePath))
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
					result = xmlSerializer.Deserialize(reader);
				}
			}
			
			return result;
		}
		catch
		{
			return null;
		}
	}
}