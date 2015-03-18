using System.Collections.Generic;

using DuoCode.Dom;
using DuoCode.JQuery;
using DuoCode.Runtime;

namespace Mindbox.PostAddress
{
	public class AutocompleteDefaults
	{
		public void OnSuccess(
			List<SimpleSettlementAutocompleteViewModel> autocompleteResult,
			string responseStatus,
			JqXHR<
				JsArray<SimpleSettlementAutocompleteViewModel>,
				JsonDeserializer<JsArray<SimpleSettlementAutocompleteViewModel>>> jqXhr
			)
		{
			Global.console.log("Default Autocomplete OnSuccess");
			foreach (var result in autocompleteResult)
			{
				Global.console.log(result);
			}
		}
	}
}