using System;

namespace Mindbox.PostAddress
{
	public class ElementNotFoundException : Exception
	{
		public ElementNotFoundException(string message)
			: base(message)
		{
		}
	}
}