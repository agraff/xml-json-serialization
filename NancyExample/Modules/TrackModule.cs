using System;
using Nancy;
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
					Track = TestData.GetTrack()
				};
		}
	}
}