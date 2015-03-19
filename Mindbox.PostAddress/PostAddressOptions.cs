using System;
using System.Collections.Generic;

using DuoCode.Runtime;

namespace Mindbox.PostAddress
{
	public class PostAddressOptions
	{
		public PostAddressOptions()
		{
		}

		public PostAddressOptions(dynamic options)
		{
			var jsOptions = options as JsObject;
			if (jsOptions == null)
				return;

			Debug = jsOptions["debug"].As<bool>();
			OnAutocompleteSuccess = jsOptions["onAutocompleteSuccess"].As<Action<JsArray<SimpleSettlementAutocompleteViewModel>>>();
		}

		public bool Debug { get; set; }

		public Action<JsArray<SimpleSettlementAutocompleteViewModel>> OnAutocompleteSuccess { get; set; }
	}
}