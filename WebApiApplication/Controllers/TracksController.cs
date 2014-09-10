using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApplication.DomainObjects;

namespace WebApiApplication.Controllers
{
	public class TracksController : ApiController
	{
		// GET api/tracks
		//public Response Get()
		//{
		//	return TestData.GetTracksResponse();
		//}

		public TracksPage Get()
		{
			return TestData.GetTracksPage();
		}
	}
}