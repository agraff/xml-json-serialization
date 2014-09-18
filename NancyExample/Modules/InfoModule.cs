using System;
using Nancy;
using NancyExample.ViewModels;
using ViewModels;

namespace NancyExample.Modules
{
	public class InfoModule : NancyModule
	{
		public InfoModule()
		{
			Get["/info"] = parameters => _Get();
		}

		public WrappedInfoViewModel _Get()
		{
			return new WrappedInfoViewModel
				{
					Info = TestData.GetInfo("Nancy")
				};
		}
	}
}