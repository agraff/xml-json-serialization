﻿using Nancy;
using NancyExample.ViewModels;
using ViewModels;

namespace NancyExample.Modules
{
	public class TracksModule : NancyModule
	{
		public TracksModule()
		{
			Get["/tracks"] = parameters => _Get();
		}

		public WrappedTracksViewModel _Get()
		{
			return new WrappedTracksViewModel
			{
				Tracks = TestData.GetPaginatedTracks()
			};
		}
	}
}