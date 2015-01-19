using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRootAttribute("root", Namespace = "abc.abc", IsNullable = false)]
public class ChapterDataMgr
{
	private static ChapterDataMgr m_instance;

	public static string m_sConfigFile = @"/Download/Config/Level.xml";

	[XmlIgnore]
	private Dictionary<DataType, Dictionary<DataSubType, List<string> > > bagItemClassify 
		= new Dictionary<DataType, Dictionary<DataSubType, List<string> > >();

	public static ChapterDataMgr Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = (ChapterDataMgr)FileLoader.LoadXML(m_sConfigFile, typeof(ChapterDataMgr));
				if (m_instance == null)
				{
					Debug.Log("Empty config.");
					m_instance = new ChapterDataMgr();
					m_instance.MakeFakeData();
				}
				else
				{
					Debug.Log("Load config.");

					foreach (Section chapter in ChapterDataMgr.Instance.chapters)
					{
						Debug.Log(chapter.title);

						foreach (Sence section in chapter.sections)
						{
							Debug.Log(section.title);
						}
					}
				}
			}
			return m_instance;
		}
	}

	public void MakeFakeData()
	{
		Section section = new Section();
		section.title = "哈哈哈";
		section.desc = "哈哈哈哈";
		section.background = "bbg_fall_bridge.jpg";

		Sence scene = new Sence();
		scene.title = "哈哈哈";
		scene.desc = "哈哈哈";
		scene.background = "bbg_fall_bridge.jpg";

		section.sections.Add(scene);

		chapters.Add(section);
	}

	[XmlArrayAttribute("Sections")]
	public List<Section> chapters = new List<Section>();
}
