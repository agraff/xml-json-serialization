using System;
using System.Collections.Generic;
using ViewModels;

namespace NancyExample.DomainObjects
{
	public class TestData
	{
		public TracksResponse GetTracksResponse()
		{
			var track1 = new TrackViewModel
				{
					Title = "First Track",
					Number = 1,
					ReleaseDateTime = new DateTime(1998, 03, 21, 09, 30, 00, DateTimeKind.Utc)
				};

			var track2 = new TrackViewModel
				{
					Title = "Another Track",
					Number = 5,
					ReleaseDateTime = new DateTime(2009, 12, 07, 11, 45, 23, DateTimeKind.Utc)
				};

			var track3 = new TrackViewModel
				{
					Title = "Final Track",
					Number = 13,
					ReleaseDateTime = new DateTime(2014, 07, 30, 17, 12, 56, DateTimeKind.Utc)
				};

			return new TracksResponse
			{
					Tracks = new TrackList
						{
							Page = 2,
							PageSize = 3,
							TotalItems = 1423,
							Tracks = new List<TrackViewModel> { track1, track2, track3 }
						}
				};
		}
	}
}