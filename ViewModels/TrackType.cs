﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ViewModels
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum TrackType
	{
		[EnumMember(Value = "audio")]
		Audio = 1,
		Video = 2,
		Pdf = 3,
		Zip = 4
	}
}
