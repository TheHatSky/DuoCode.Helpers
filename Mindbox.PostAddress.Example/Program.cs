using System;
using DuoCode.Dom;
using DuoCode.JQuery;
using DuoCode.Runtime;

namespace Mindbox.PostAddress.Example
{
	static class Program
	{
		static void Run() // HTML body.onload event entry point, see index.html
		{
			PostAddress.Initialize(
				new PostAddressOptions
				{
					Debug = true
				});
		}
	}
}
