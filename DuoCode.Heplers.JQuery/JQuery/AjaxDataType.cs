// ReSharper disable InconsistentNaming
namespace DuoCode.JQuery
{
	public enum AjaxDataType
	{
		/// <summary>
		/// Returns a XML document that can be processed via jQuery.
		/// </summary>
		xml,

		/// <summary>
		/// Returns HTML as plain text; included script tags are evaluated when inserted in the DOM.
		/// </summary>
		html,

		/// <summary>
		/// Evaluates the response as JavaScript and returns it as plain text.
		/// Disables caching by appending a query string parameter, "_=[TIMESTAMP]",
		/// to the URL unless the <c>cache</c> option is set to <c>true</c>.
		/// <para>Note: This will turn POSTs into GETs for remote-domain requests.</para>
		/// </summary>
		script,

		/// <summary>
		/// <para>Evaluates the response as JSON and returns a JavaScript object.
		/// The JSON data is parsed in a strict manner; any malformed JSON is rejected and a parse error is thrown.</para>
		/// <para>As of jQuery 1.9, an empty response is also rejected; the server should return a response of null or {} instead.</para>
		/// <para>(See http://json.org for more information on proper JSON formatting.)</para>
		/// </summary>
		json,

		/// <summary>
		/// <para>Loads in a JSON block using JSONP. Adds an extra "?callback=?" to the end of your URL to specify the callback.</para>
		/// <para>Disables caching by appending a query string parameter, "_=[TIMESTAMP]",
		/// to the URL unless the <c>cache</c> option is set to <c>true</c>.</para>
		/// </summary>
		jsonp,

		/// <summary>
		/// A plain text string.
		/// </summary>
		text
	}
}