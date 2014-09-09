using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;

namespace WebApiApplication.Controllers
{
	public class TracksController : ApiController
	{
		// GET api/tracks
		public TracksResponse Get()
		{
			return new Domain.TestData().GetTracksResponse();
		}
	}
}