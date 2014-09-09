using System.Collections.Generic;

namespace Domain
{
	public class TracksResponse : Response
	{
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