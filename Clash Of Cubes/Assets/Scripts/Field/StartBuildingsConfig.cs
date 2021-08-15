using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace StartBuildingsXML
{
    [System.Serializable]
	[XmlRoot(ElementName="location")]
	public class Location {
		[XmlAttribute(AttributeName="x")]
		public string X { get; set; }
		[XmlAttribute(AttributeName="y")]
		public string Y { get; set; }
	}

    [System.Serializable]
	[XmlRoot(ElementName="building")]
	public class Building {
		[XmlElement(ElementName="location")]
		public Location Location { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
	}

    [System.Serializable]
	[XmlRoot(ElementName="buildings")]
	public class Buildings {
		[XmlElement(ElementName="building")]
		public List<Building> Building { get; set; }
	}

	[XmlRoot(ElementName="xml")]
    // [XmlRoot(ElementName = "xml", DataType = "string", IsNullable=true)]
	public class Xml {
		[XmlElement(ElementName="buildings")]
		public Buildings Buildings { get; set; }
	}

}


public static class StartBuildingsConfig
{
    public static List<StartBuildingsXML.Building> LoadData()
    {
        string filepath = Application.dataPath + @"/Resources/XML/Start Buildings.xml";

        using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "xml";
            xRoot.IsNullable = true;

            XmlSerializer xs = new XmlSerializer(typeof(StartBuildingsXML.Xml),xRoot);
            var result = xs.Deserialize(fs) as StartBuildingsXML.Xml;
            
            Debug.Log("Объект десериализован");
            Debug.Log($"Имя: {result.Buildings.Building[0].Name} --- Location: {result.Buildings.Building[0].Location}" +
                    result.Buildings.Building[0].Location.X + result.Buildings.Building[0].Location.Y);
            return result.Buildings.Building;
        }
    }
}
