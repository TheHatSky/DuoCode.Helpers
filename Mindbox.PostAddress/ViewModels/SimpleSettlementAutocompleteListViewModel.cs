using System.Collections.Generic;
using System.Linq;

namespace Mindbox.PostAddress
{

	public class SimpleSettlementAutocompleteListViewModel
	{

		public SimpleSettlementAutocompleteListViewModel()
		{
			Settlements = new List<SimpleSettlementAutocompleteViewModel>();
		}


		public IList<SimpleSettlementAutocompleteViewModel> Settlements { get; private set; }


		public object ToJson()
		{
			return Settlements.Select(settlement => settlement.ToJson()).ToList();
		}
	}

}
