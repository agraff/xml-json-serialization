using System;

namespace NancyExample.Serializers
{
	[AttributeUsage(AttributeTargets.Property)]
	public class JsonRootObject : Attribute
	{
	}
}