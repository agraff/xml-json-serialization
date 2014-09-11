using System.Xml.Serialization;

namespace WebApiApplication.DomainObjects
{
	[XmlRoot("response")]
	public class TracksResponse : Response
	{
		[XmlElement("tracks")]
		public TracksPage TracksPage { get; set; }
	}
}