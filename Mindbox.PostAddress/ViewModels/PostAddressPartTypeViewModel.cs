using System.Diagnostics.CodeAnalysis;

using DuoCode.Runtime;

namespace Mindbox.PostAddress
{
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate")]
	public class PostAddressPartTypeViewModel : PostAddressPartViewModel
	{
		public PostAddressPartTypeViewModel() { }

		public PostAddressPartTypeViewModel(
			string objectTypeDisplayName,
			string objectTypeShortName,
			string objectTypeFullName,
			int objectTypeId)
		{
			Text = objectTypeDisplayName;
			ShortName = objectTypeShortName;
			FullName = objectTypeFullName;
			SetId(objectTypeId);
		}

		[Js(Name = "fullName")]
		public string FullName;
		[Js(Name = "shortName")]
		public string ShortName;
	}
}
