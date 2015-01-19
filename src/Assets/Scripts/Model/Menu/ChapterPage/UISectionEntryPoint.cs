using UnityEngine;
using System.Collections;

public class UISectionEntryPoint : MonoBehaviour {
	public static UISectionEntryPoint Instance
	{
		get
		{
			return ResourceManager.Load("Prefab/Menu/ChapterPage/SectionEntryPoint").GetComponent<UISectionEntryPoint>();
		}
	}

	public Sence SectionData
	{
		get {
			return m_section;
		}
		set {
			m_section = value;
			gameObject.FindChild("SectionName").GetComponent<UILabel>().text = m_section.title;
		}
	}

	private Sence m_section = new Sence();
}
