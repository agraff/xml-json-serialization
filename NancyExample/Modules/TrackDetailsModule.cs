using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using NancyExample.ViewModels;
using ViewModels;

namespace NancyExample.Modules
{
	public class TrackDetailsModule : NancyModule
	{
		public TrackDetailsModule()
		{
			Get["/trackdetails"] = parameters => _Get();
		}

		private WrappedTrackDetailsViewModel _Get()
		{
			var wrappedDetails = new WrappedTrackDetailsViewModel {Track = TestData.GetTrackDetails()};

			return wrappedDetails;


		}
	}
}