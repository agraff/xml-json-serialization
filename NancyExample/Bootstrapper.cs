using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using SevenDigital.Serialization.Unwrapped.Nancy;

namespace NancyExample
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override NancyInternalConfiguration InternalConfiguration
		{
			get { return UnwrappedSerializersConfiguration.GetInternalConfiguration(); }
		}

		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			base.ConfigureApplicationContainer(container);
			UnwrappedSerializersConfiguration.ConfigureApplicationContainer(container);
			
		}
	}
}