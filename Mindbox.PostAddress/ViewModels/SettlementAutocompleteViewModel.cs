using System;
using System.Collections.Generic;
using System.Globalization;
using Itc.DirectCrm.Model;

namespace Mindbox.PostAddress
{

	public class SettlementAutocompleteViewModel
	{

		public SettlementAutocompleteViewModel() { }

		public SettlementAutocompleteViewModel(Settlement settlement)
		{
			if (settlement == null)
				throw new ArgumentNullException("settlement");

			Text = settlement.ObjectType.FullName == ObjectTypeRepository.CityObjectTypeFullName ?
				settlement.Name :
				settlement.GetNameWithShortType();
			Value = settlement.Id.ToString(CultureInfo.InvariantCulture);
		}


		public string Text { get; set; }
		public string Value { get; set; }


		public Dictionary<string, object> ToJson()
		{
			return new Dictionary<string, object>
			{
				{ "text", Text },
				{ "value", Value }
			};
		}
	}

}
