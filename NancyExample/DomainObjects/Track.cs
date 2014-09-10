using System;
using System.Xml.Serialization;

namespace NancyExample.DomainObjects
{
	public class Track
	{
		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("number")]
		public int Number { get; set; }

		[XmlElement("releaseDateTime")]
		public DateTime ReleaseDateTime { get; set; }
	}
}