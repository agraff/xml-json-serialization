using Domain;
using Nancy;
using Nancy.ModelBinding;

namespace NancyExample
{
	public class ExampleModule : NancyModule
	{
		private TestData _testData;

		public ExampleModule()
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