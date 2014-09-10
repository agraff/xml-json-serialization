using System.Web.Http;
using WebApiApplication.DomainObjects;

namespace WebApiApplication.Controllers
{
	public class TracksController : ApiController
	{
		// GET api/tracks
		public TracksPage Get()
		{
			return TestData.GetTracksPage();
		}
	}
}