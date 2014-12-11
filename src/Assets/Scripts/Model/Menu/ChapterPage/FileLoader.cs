using UnityEngine;
using System.Collections;
using System.IO;

using System.Xml;
using System.Xml.Serialization;
using System.Text;

public class FileLoader{

	private static string GetFilePath(string name)
	{
		if (Application.platform == RuntimePlatform.WindowsEditor 
		    || Application.platform == RuntimePlatform .WindowsPlayer)
		{
			return Application.dataPath + @"/" + name;
		}
		else
		{
			return Application.persistentDataPath + @"/" + name;
		}
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

	public static object LoadXML(string name, System.Type type)   
	{   
		string filePath = GetFilePath(name);

		FileInfo t = new FileInfo(filePath);

		Debug.Log("load xml:" + filePath);

		if(t.Exists)   
		{   
			StreamReader r = t.OpenText();   
			string _info = r.ReadToEnd();  
			r.Close();   
			if(_info.ToString() != "")
			{   
				return DeserializeObject(_info, type);                
			}
		}   
		return null;
	}

	public static void SaveXml(string name, object pObject, System.Type type)
	{    
		string filePath = GetFilePath(name);

		FileInfo t = new FileInfo(filePath);

		Debug.Log("save xml:" + filePath);

		string _data = SerializeObject(pObject, type);   
		StreamWriter writer;   
		if(t.Exists)   
		{   
			t.Delete();    
		}
		writer = t.CreateText();   
		writer.Write(_data);  

		writer.Close();
		writer.Dispose ();
	}

	public static object DeserializeObject(string pXmlizedString, System.Type type)   
	{   
		XmlSerializer xs = new XmlSerializer(type);   
		MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(pXmlizedString));   
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);   
		return xs.Deserialize(memoryStream);   
	}

	public static string SerializeObject(object pObject, System.Type type)
	{  
		string XmlizedString = null;   
		MemoryStream memoryStream = new MemoryStream();   
		XmlSerializer xs = new XmlSerializer(type);   
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);   
		xs.Serialize(xmlTextWriter, pObject);   
		memoryStream = (MemoryStream)xmlTextWriter.BaseStream;   
		XmlizedString = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());   
		return XmlizedString;   
	}
}
