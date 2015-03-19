using System.Collections.Generic;

using DuoCode.Dom;
using DuoCode.JQuery;

namespace Mindbox.PostAddress
{
	public class AutocompleteDefaults
	{
		public void OnSuccess(List<SimpleSettlementAutocompleteViewModel> autocompleteResult)
		{
			var test = JQuery.ForSelector("#test").Html(string.Empty);

			foreach (var result in autocompleteResult)
				test.Append(
					string.Format("{0}: {1} - {2} - {3}<br/>",
						result.PostIndex,
						result.RegionName,
						result.DistrictName,
						result.SettlementName)
					);
		}
	}
}