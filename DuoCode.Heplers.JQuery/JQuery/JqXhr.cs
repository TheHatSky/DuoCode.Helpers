using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
	public abstract class JqXHR : XMLHttpRequest
	{
		[Obsolete("Can not be used in JqXhr", true)]
		public new Func<Event, dynamic> onreadystatechange { get; set; }

		[Js(Name = "responseJSON")]
		public JsObject responseJSON;

		[Js(Name = "done")]
		private Action<dynamic, string, JqXHR> done;
		[Js(Name = "fail")]
		private Action<JqXHR, string, string> fail;

		/// <summary>
		/// An alternative construct to the success callback option, the <see cref="OnDoneDynamic"/> method replaces
		/// the deprecated jqXHR.success() method.
		/// <para>Refer to deferred.done() for implementation details.</para>
		/// </summary>
		protected Action<dynamic, string, JqXHR> OnDoneDynamic
		{
			get { return done; }
			set { done = value; }
		}

		/// <summary>
		/// An alternative construct to the error callback option, the <see cref="OnFail"/> method replaces
		/// the deprecated .error() method.
		/// <para>Refer to deferred.fail() for implementation details.</para>
		/// </summary>
		public Action<JqXHR, string, string> OnFail
		{
			get { return fail; }
			set { fail = value; }
		}
	}
}