using Nancy;
using Nancy.ModelBinding;
using NancyExample.DomainObjects;
using ViewModels;

namespace NancyExample.Modules
{
	public class TracksModule : NancyModule
	{

		public TracksModule()
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