using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WebApiApplication.DomainObjects
{
	[XmlRoot("track")]
	[DataContract(Namespace = "track")]
	public class Track
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
	}
}