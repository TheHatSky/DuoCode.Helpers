using System.Collections.Generic;
using System.Linq;

namespace Mindbox.PostAddress
{

	public class SettlementAutocompleteListViewModel
	{

		public SettlementAutocompleteListViewModel()
		{
			Settlements = new List<SettlementAutocompleteViewModel>();
		}


		public IList<SettlementAutocompleteViewModel> Settlements { get; private set; }


		public object ToJson()
		{
			return Settlements.Select(settlement => settlement.ToJson()).ToList();
		}
	}

}
