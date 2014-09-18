using System;
using Nancy;
using Nancy.ModelBinding;
using NancyExample.ViewModels;
using ViewModels;

namespace NancyExample.Modules
{
	public class TrackModule : NancyModule
	{
		public TrackModule()
		{
			Get["/track"] = parameters => _Get();
		}

		public WrappedTrackViewModel _Get()
		{
			return new WrappedTrackViewModel
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