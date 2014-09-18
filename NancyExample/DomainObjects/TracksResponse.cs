using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using ViewModels;

namespace NancyExample.DomainObjects
{
	[XmlRoot("response")]
	public class TracksResponse : Response
	{
		[XmlElement("tracks")]
		[DataMember(Name = "tracks")]
		public TrackList Tracks { get; set; }
	}

	public class TrackList
	{
		[XmlElement("page")]
		public int Page { get; set; }
	
		[XmlElement("pageSize")]
		public int PageSize { get; set; }

		[XmlElement("totalItems")]
		public int TotalItems { get; set; }

		[XmlElement("track")]
		public List<Track> Tracks { get; set; }
	}
}