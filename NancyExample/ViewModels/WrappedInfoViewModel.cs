using System.Xml.Serialization;
using ViewModels;

namespace NancyExample.ViewModels
{
	[XmlRoot("response")]
	public class WrappedInfoViewModel : ResponseViewModel
	{
		[XmlElement("info")]
		public InfoViewModel Info { get; set; }
	}
}