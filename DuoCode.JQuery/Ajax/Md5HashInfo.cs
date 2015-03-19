using System.Diagnostics.CodeAnalysis;

using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
	// This provides typeof(Md5HashInfo).GetProperties() to be implemented in compiled js.
	[Js(ReflectionLevel = ReflectionLevel.Partial)]
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate")]
	public class Md5HashInfo
	{
		[Js(Name = "md5")]
		public string Md5Hash;

		[Js(Name = "original")]
		public string Text;

		public void Foo()
		{
			Global.console.log(string.Format("text: {0}\nmd5: {1}", Text, Md5Hash));
		}
	}
}