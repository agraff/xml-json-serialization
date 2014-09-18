using System;
using System.Web.Http;
using ViewModels;

namespace WebApiApplication.Controllers
{
	public class InfoController : ApiController
	{
		public InfoViewModel Get()
		{
			return TestData.GetInfo("WebApi");
		}
	}
}