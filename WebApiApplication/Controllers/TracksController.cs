using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApplication.DomainObjects;

namespace WebApiApplication.Controllers
{
	public class TracksController : ApiController
	{
		public TracksResponse Get()
		{
			return TestData.GetTracksPage();
		}
	}
}