using System;

namespace DuoCode.JQuery
{
	public class JsonNameAttribute : Attribute
	{
		public string Name { get; private set; }

		public JsonNameAttribute(string name)
		{
			Name = name;
		}
	}
}
