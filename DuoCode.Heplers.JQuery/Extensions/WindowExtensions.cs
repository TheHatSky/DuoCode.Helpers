using System;
using DuoCode.Dom;

namespace DuoCode.JQuery
{
	public static class WindowExtensions
	{
		public static object Eval(
			this Window window,
			string code)
		{
			if (window == null)
				throw new ArgumentNullException("window");
			if (string.IsNullOrEmpty(code))
				throw new ArgumentNullException("code");

			return ((dynamic)window).eval(code);
		}
	}
}
