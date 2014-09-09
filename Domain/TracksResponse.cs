using System.Collections.Generic;

namespace Domain
{
	public class TracksResponse
	{
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int PageNumber { get; set; }
		public List<Track> Tracks { get; set; }
	}
}