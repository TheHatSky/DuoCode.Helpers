using System;
using System.Collections.Generic;
using System.Globalization;
using Itc.DirectCrm.Model;

namespace Mindbox.PostAddress
{

	public class StreetAutocompleteViewModel
	{

		public StreetAutocompleteViewModel(Street street, PostIndex index)
		{
			if (street == null)
				throw new ArgumentNullException("street");

			Name = street.Name;
			StreetType = street.TypeId.ToString(CultureInfo.InvariantCulture);
			StreetTypeName = street.ObjectType.FullName.ToLower();
			Text = street.GetNameWithShortType();
			if (index != null)
				PostIndex = index.IndexValue.ToString();
		}


		public string Name { get; set; }
		public string StreetType { get; set; }
		public string StreetTypeName { get; set; }
		public string Text { get; set; }
		public string PostIndex { get; set; }


		public Dictionary<string, object> ToJson()
		{
			return new Dictionary<string, object>
			{
				{ "name", Name },
				{ "type", StreetType },
				{ "typename", StreetTypeName },
				{ "text", Text },
				{ "postIndex", PostIndex }
			};
		}
	}

}
