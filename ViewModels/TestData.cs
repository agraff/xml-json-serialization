using System;
using System.Collections.Generic;

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

		public static TrackDetailsViewModel GetTrackDetails()
		{
			var trackDetails = new TrackDetailsViewModel { Id = 12345, Title = "I Love You", Version = string.Empty, Duration = 252, TrackNumber = 5, Isrc = "USCA29600191", Url = @"http://www.7digital.com/artist/the-dandy-warhols/release/the-dandy-warhols-come-down/?partner=1401&h=05", StreamingReleaseDate = DateTime.Parse("1997-07-03T00:00:00Z").ToUniversalTime(), DiscNumber = 1, Number = 5, PreviewDate = DateTime.Parse("1997-07-03T00:00:00Z").ToUniversalTime() };
			trackDetails.Artist = new Artist() { Id = 437, Name = "The Dandy Warhols", AppearsAs = "The Dandy Warhols", Url = @"http://www.7digital.com/artist/the-dandy-warhols/?partner=1401" };
			trackDetails.Price = new Price(){Currency = new CurrencyResource(){Code = "GBP", Symbol = "£"}, Value = "0.99", FormattedPrice = "£0.99", FormattedRrp = "£0.99", Rrp = "0.99"};
			trackDetails.Release = new TrackReleaseViewModel() { Artist = trackDetails.Artist, Id = 1302, Title = "...The Dandy Warhols Come Down", Version = string.Empty, Type = "album", Barcode = "00724349501058", ReleaseDate = DateTime.Parse("1997-07-03T00:00:00Z").ToUniversalTime(), Url = @"http://www.7digital.com/artist/the-dandy-warhols/release/the-dandy-warhols-come-down/?partner=1401", Image = @"http://artwork-cdn.7static.com/static/img/sleeveart/00/000/013/0000001302_50.jpg" };
			trackDetails.Formats.Formats.Add(new Format(){BitRate = 320,DrmFree = true,FileFormat = "MP3", Id = 17});
			trackDetails.Formats.AvailableDrmFree = true;
			trackDetails.Download = new Download() {Packages = new List<PackageResponse>()};
			trackDetails.Download.Packages.Add(new PackageResponse(){Description = "standard", Id = 2, Price = new PackagePriceResponse(){CurrencyCode = "GBP",RecommendedRetailPrice = (decimal?) 0.99, SevendigitalPrice = (decimal?) 0.99},Formats = new List<PackageFormat>(){new PackageFormat(){Description = "MP3 320", Id = 17}}});
			

			return trackDetails;
		}
	}

}