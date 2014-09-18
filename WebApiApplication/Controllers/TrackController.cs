using System;
using System.Web.Http;
using ViewModels;

namespace WebApiApplication.Controllers
{
	public class TrackController : ApiController
	{
		public TrackViewModel Get()
		{
			return TestData.GetTrack();
		}
	}
}