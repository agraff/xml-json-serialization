using System;

namespace ViewModels
{
	public static class TestData
	{
		public static TracksViewModel GetTracksViewModel()
		{
			return new TracksViewModel
			{
				Page = 2,
				PageSize = 3,
				TotalItems = 1423,
				Tracks = GetTracks()
			};
		}

		private static TrackViewModel[] GetTracks()
		{
			return new[]
			{
				new TrackViewModel
				{
					Title = "First Track",
					Number = 1,
					ReleaseDateTime = new DateTime(1998, 03, 21, 09, 30, 00, DateTimeKind.Utc)
				},
				new TrackViewModel
				{
					Title = "Another Track",
					Number = 5,
					ReleaseDateTime = new DateTime(2009, 12, 07, 11, 45, 23, DateTimeKind.Utc)
				},
				new TrackViewModel
				{
					Title = "Final Track",
					Number = 13,
					ReleaseDateTime = new DateTime(2014, 07, 30, 17, 12, 56, DateTimeKind.Utc)
				}
			};
		}
	}
}