using System;
using System.Web.Http;
using ViewModels;

namespace WebApiApplication.Controllers
{
	public class TrackController : ApiController
	{
		public Track Get()
		{
			return new Track
				{
					ReleaseDateTime = new DateTime(1998, 03, 21, 09, 30, 00, DateTimeKind.Utc),
					Number = 1,
					Title = "Hello"
				};
		}
	}
}