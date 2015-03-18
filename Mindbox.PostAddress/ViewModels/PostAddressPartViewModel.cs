using System.Diagnostics.CodeAnalysis;

using DuoCode.Runtime;

namespace Mindbox.PostAddress
{
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate")]
	public class PostAddressPartViewModel
	{
		public PostAddressPartViewModel()
		{
			Selectable = true;
		}

		[Js(Name = "text")]
		public string Text;
		[Js(Name = "value")]
		public string Value;
		[Js(Name = "selectable")]
		public bool Selectable;

		public void SetId(int id)
		{
			Value = id.ToString();
		}
	}
}
