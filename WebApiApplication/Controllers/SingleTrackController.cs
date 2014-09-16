using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiApplication.DomainObjects;

namespace WebApiApplication.Controllers
{
	public class SingleTrackController : ApiController
	{
		public SingleTrackResponse Get()
		{
			return new SingleTrackResponse
			{
				Track = new Track
				{
					ReleaseDateTime = new DateTime(1998, 03, 21, 09, 30, 00, DateTimeKind.Utc),
					Number = 1,
					Title = "Hello"
				}
			};
		}
	}
}