using Nancy;
using Nancy.ModelBinding;
using NancyExample.DomainObjects;

namespace NancyExample
{
	public class ReturnsACollectionModule : NancyModule
	{
		private TestData _testData;

		public ReturnsACollectionModule()
		{
			_testData = new TestData();

			Get["/tracks"] = parameters =>
			{
				var request = this.Bind<TracksRequest>();

				return _Get(request);
			};
		}

		public TracksResponse _Get(TracksRequest request)
		{
			return _testData.GetTracksResponse();
		}
	}

}