using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ViewModels
{
	[XmlRoot("track")]
	public class TrackViewModel
	{
		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("number")]
		public int Number { get; set; }

		[XmlElement("releaseDateTime")]
		public DateTime ReleaseDateTime { get; set; }

		[XmlElement("type")]
		public TypeEnum Type { get; set; }
	}
}