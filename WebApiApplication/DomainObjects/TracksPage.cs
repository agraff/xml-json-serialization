using System.Collections.Generic;

namespace WebApiApplication.DomainObjects
{
	public class TracksPage
	{
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int PageNumber { get; set; }
		public IEnumerable<Track> Tracks { get; set; }
	}
}