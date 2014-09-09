using System.Collections.Generic;

namespace WebApiApplication.DomainObjects
{
	public class TrackList
	{
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int PageNumber { get; set; }
		public List<Track> Track { get; set; }
	}
}