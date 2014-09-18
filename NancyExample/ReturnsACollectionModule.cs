using Nancy;
using Nancy.ModelBinding;
using NancyExample.DomainObjects;
using ViewModels;

namespace NancyExample
{
	public class ReturnsACollectionModule : NancyModule
	{

		public ReturnsACollectionModule()
		{
			Get["/tracks"] = parameters =>
			{
				var request = this.Bind<TracksRequest>();

				return _Get(request);
			};
		}

		public TracksResponse _Get(TracksRequest request)
		{
			return new TracksResponse()
			{
				Tracks = TestData.GetTracksViewModel()
			};
		}
	}

}