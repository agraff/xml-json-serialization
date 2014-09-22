using System;

namespace ViewModels
{
	public static class TestData
	{
		public static TracksViewModel GetPaginatedTracks()
		{
			return new TracksViewModel
			{
				Page = 2,
				PageSize = 3,
				TotalItems = 1423,
				Tracks = GetTracks()
			};
		}

		public static TrackViewModel[] GetTracks()
		{
			return new[]
			{
				new TrackViewModel
				{
					Title = "First Track",
					Number = 1,
					ReleaseDateTime = new DateTime(1998, 03, 21, 09, 30, 00, DateTimeKind.Utc),
					Type = TypeEnum.TypeA
				},
				new TrackViewModel
				{
					Title = "Another Track",
					Number = 5,
					ReleaseDateTime = new DateTime(2009, 12, 07, 11, 45, 23, DateTimeKind.Utc),
					Type = TypeEnum.TypeB
				},
				new TrackViewModel
				{
					Title = "Final Track",
					Number = 13,
					ReleaseDateTime = new DateTime(2014, 07, 30, 17, 12, 56, DateTimeKind.Utc),
					Type = TypeEnum.TypeC
				}
			};
		}

		public static TrackViewModel GetTrack()
		{
			return GetTracks()[0];
		}

		public static InfoViewModel GetInfo(string apiType)
		{
			return new InfoViewModel
			{
				Technology = apiType
			};
		}
	}
}