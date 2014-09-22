using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ViewModels
{
	[XmlRoot("track")]
	[DataContract(Namespace = "track")]
	public class TrackViewModel
	{
		[XmlElement("title")]
		[DataMember]
		public string Title { get; set; }

		[XmlElement("number")]
		[DataMember]
		public int Number { get; set; }

		[XmlElement("releaseDateTime")]
		[DataMember]
		public DateTime ReleaseDateTime { get; set; }

		[XmlElement("type")]
		[DataMember]
		public TypeEnum Type { get; set; }
	}
}