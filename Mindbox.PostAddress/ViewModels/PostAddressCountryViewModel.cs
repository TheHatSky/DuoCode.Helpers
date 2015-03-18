using System.Diagnostics.CodeAnalysis;

using DuoCode.Runtime;

namespace Mindbox.PostAddress
{
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate")]
	public class PostAddressCountryViewModel : PostAddressPartViewModel
	{
		public PostAddressCountryViewModel()
		{
		}

		public PostAddressCountryViewModel(
			string countryName,
			int countryId,
			bool isAddressStructured)
		{
			Text = countryName;
			SetId(countryId);
			IsAddressStructured = isAddressStructured;
		}

		[Js(Name = "isAddressStructured")]
		public bool IsAddressStructured;
	}
}