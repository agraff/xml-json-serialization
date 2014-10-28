using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyExample.Modules
{
	public class TrackDetails : NancyModule
	{
		public TrackDetails()
		{
			Get["/trackdetails"] = parameters => _Get();
		}

		private TrackDetailsResponse _Get()
		{
			return new TrackDetailsResponse();
		}
	}
}