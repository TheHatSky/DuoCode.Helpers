using System.Collections.Generic;
using System.Linq;

namespace Mindbox.PostAddress
{

	public class StreetAutocompleteListViewModel
	{

		public StreetAutocompleteListViewModel()
		{
			Streets = new List<StreetAutocompleteViewModel>();
		}


		public IList<StreetAutocompleteViewModel> Streets { get; private set; }


		public object ToJson()
		{
			return Streets.Select(street => street.ToJson()).ToList();
		}
	}

}
