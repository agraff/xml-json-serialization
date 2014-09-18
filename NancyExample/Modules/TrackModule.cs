﻿using System;
using Nancy;
using Nancy.ModelBinding;
using NancyExample.DomainObjects;
using ViewModels;

namespace NancyExample.Modules
{
	public class TrackModule : NancyModule
	{

		public TrackModule()
		{
			Get["/track"] = parameters =>
			{
				var request = this.Bind<TrackRequest>();

				return _Get(request);
			};
		}

		public SingleTrackResponse _Get(TrackRequest request)
		{
			return new SingleTrackResponse
				{
					Track = new TrackViewModel
					{
						ReleaseDateTime = new DateTime(1998, 03, 21, 09, 30, 00, DateTimeKind.Utc),
						Number = 1,
						Title = "Hello"
					}
				};
		}
	}
}