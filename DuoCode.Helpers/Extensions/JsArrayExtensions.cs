using System;
using System.Collections.Generic;
using System.Linq;

using DuoCode.Runtime;

namespace DuoCode.Helpers
{
	public static class JsArrayExtensions
	{
		// Only to hide bugz in intellisence
		public static List<T> ToList<T>(this JsArray<T> source)
		{
			return Enumerable.ToList(source);
		}

		// Only to hide bugz in intellisence
		public static int Count<T>(this List<T> source)
		{
			return Enumerable.Count(source);
		}
	}
}
