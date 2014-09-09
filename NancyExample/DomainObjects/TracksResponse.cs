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
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int PageNumber { get; set; }
		public List<Track> Track { get; set; }
	}
}