using System.Web.Http;
using ViewModels;

namespace WebApiApplication.Controllers
{
	public class TracksController : ApiController
	{
		public TracksViewModel Get()
		{
			return TestData.GetPaginatedTracks();
		}
	}
}