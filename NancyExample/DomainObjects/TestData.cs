namespace NancyExample.DomainObjects
{
	public class TestData
	{
		public TracksResponse GetTracksResponse()
		{
			return new TracksResponse
			{
				Tracks = new TrackList
					{
						Page = 2,
						PageSize = 3,
						TotalItems = 1423,
						Tracks = ViewModels.TestData.GetTracks()
					}
			};
		}
	}
}