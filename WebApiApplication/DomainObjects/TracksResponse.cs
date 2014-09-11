using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebApiApplication.DomainObjects
{
	[XmlRoot("tracks")]
	public class TracksResponse
	{
		[XmlElement("page")]
		public int Page { get; set; }

		[XmlElement("pageSize")]
		public int PageSize { get; set; }

		[XmlElement("totalItems")]
		public int TotalItems { get; set; }

		[XmlElement("track")]
		public Track[] Tracks { get; set; }
	}
}