using System.Xml.Serialization;

namespace WebApiApplication.DomainObjects
{
	public class TracksResponse : Response
	{
		[XmlElement("tracks")]
		public TracksPage TracksPage { get; set; }
	}
}