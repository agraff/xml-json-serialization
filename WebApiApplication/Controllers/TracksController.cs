using System.Web.Http;
using WebApiApplication.DomainObjects;

namespace WebApiApplication.Controllers
{
	public class TracksController : ApiController
	{
		// GET api/tracks
		public TracksResponse Get()
		{
			return TestData.GetTracksResponse();
		}
	}
}