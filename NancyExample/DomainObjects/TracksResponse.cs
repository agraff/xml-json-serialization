using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NancyExample.DomainObjects
{
	[XmlRoot("response")]
	public class TracksResponse : Response
	{
	//	private string tracks = "hello"; 

		//[XmlElement("tracks")]
		//[DataMember(Name = "tracks")]
		//public string Tracks {
		//	get { return tracks; } 
		//	set{}}

		[XmlElement("tracks")]
		[DataMember(Name = "tracks")]
		public TrackList Tracks { get; set; }
	}

	public class TrackList
	{	
		[XmlElement("pageSize")]
		[DataMember(Name = "pageSize")]
		public int PageSize { get; set; }

		[XmlElement("totalItems")]
		[DataMember(Name = "totalItems")]
		public int TotalItems { get; set; }

		[XmlElement("page")]
		[DataMember(Name = "page")]
		public int PageNumber { get; set; }

		[XmlElement("track")]
		[DataMember(Name = "tracks")]
		public List<Track> Track { get; set; }
	}
}