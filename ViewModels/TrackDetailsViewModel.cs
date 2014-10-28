using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class TrackDetailsViewModel
	{

		public int Id { get; set; }
		public string Title { get; set; }
		public string Version { get; set; }
		public int Duration { get; set; }
		public bool IsExplicit { get; set; }
		public string Isrc { get; set; }
		public int TypeId { get; set; }
		public string Type { get { return ((TrackType)TypeId).ToString().ToLower(); } }
		public Artist Artist { get; set; }
		public bool IsBundleOnly { get; set; }
		public int Status { get; set; }
		public bool Active { get { return Status == 1; } }

		/// <summary>
		/// ie 3
		/// </summary>
		public int? DiscNumber { get; set; }
		/// <summary>
		/// ie 02
		/// </summary>
		public int TrackNumber { get; set; }
		/// <summary>
		/// ie 302 (3 is disc, 02 is track number
		/// </summary>
		public int TrackOrder { get; set; }
	}


}
