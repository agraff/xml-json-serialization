using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebApiApplication.DomainObjects
{
	public class TracksPage
	{
		[XmlElement("pageSize")]
		public int PageSize { get; set; }

		[XmlElement("totalItems")]
		public int TotalItems { get; set; }

		[XmlElement("pageNumber")]
		public int PageNumber { get; set; }

		[XmlElement("track")]
		public Track[] Tracks { get; set; }
	}
}