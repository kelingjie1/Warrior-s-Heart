using UnityEngine;
using System.Collections;
using System.IO;

public class ResourceManager
{
    public static GameObject Load(string name)
    {
        Object obj= Resources.Load(name);
        return GameObject.Instantiate(obj) as GameObject;
    }

    public static Texture2D LoadTexture(string path)
    {
        FileStream file = File.OpenRead(path);
        byte[] data = new byte[file.Length];
        file.Read(data, 0, (int)file.Length);
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(data);
        return tex;
    }
}
