using System.Collections.Generic;
using System.Xml.Serialization;

namespace NancyExample.DomainObjects
{
	[XmlRoot("response")]
	public class TracksResponse : Response
	{
		[XmlElement("tracks")]
		public TrackList Tracks { get; set; }
	}

	public class TrackList
	{
		[XmlElement("page")]
		public int PageNumber { get; set; }

		[XmlElement("pageSize")]
		public int PageSize { get; set; }

		[XmlElement("totalItems")]
		public int TotalItems { get; set; }

		[XmlElement("track")]
		public List<Track> Track { get; set; }
	}
}