using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using NancyExample.DomainObjects;

namespace NancyExample
{
	public class ReturnsSingleEntityModule :NancyModule
	{

		public ReturnsSingleEntityModule()
		{
			Get["/singleTrack"] = parameters =>
			{
				var request = this.Bind<SingleTrackRequest>();

				return _Get(request);
			};
		}

		public SingleTrackResponse _Get(SingleTrackRequest request)
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