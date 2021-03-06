﻿using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NancyExample.ViewModels
{
	public class ResponseViewModel
	{
		[XmlAttribute("status")]
		[JsonIgnore]
		public string Status = "ok";

		[XmlAttribute("version")]
		[JsonIgnore]
		public string Version = "1.2";

		[XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		[JsonIgnore]
		public string Schema = @"http://api.7digital.com/1.2/static/7digitalAPI.xsd";
	}
}
