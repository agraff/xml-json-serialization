using System.Web.Http;
using ViewModels;

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