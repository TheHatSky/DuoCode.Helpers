using System;
using System.Collections.Generic;

using DuoCode.Dom;
using DuoCode.Helpers;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
	public abstract class AjaxSettings
	{
		[Js(Name = "beforeSend")]
		private Action<JqXHR, AjaxSettings> beforeSend;
		[Js(Name = "context")]
		private HTMLElement context;
		[Js(Name = "data")]
		private JsArray data;
		[Js(Name = "dataType")]
		private string dataType;
		[Js(Name = "headers")]
		private Dictionary<string, string> headers;
		[Js(Name = "async")]
		private bool isAsync;
		[Js(Name = "cache")]
		private bool isCached;
		[Js(Name = "crossDomain")]
		private bool isCrossDomain;
		[Js(Name = "complete")]
		private Action<JqXHR, string> onComplete;
		[Js(Name = "error")]
		private Action<JqXHR, AjaxErrorTextStatus?, string> onError;
		[Js(Name = "success")]
		protected Action<dynamic, string, JqXHR> OnSuccessDynamic;
		[Js(Name = "password")]
		private string password;
		[Js(Name = "timeout")]
		private string timeoutString;
		[Js(Name = "type")]
		private string type;
		[Js(Name = "url")]
		private string url;
		[Js(Name = "global")]
		private bool useGlobalAjaxEventHandlers;
		[Js(Name = "username")]
		private string username;

		/// <summary>
		/// The type of data that you're expecting back from the server.
		/// If none is specified, jQuery will try to infer it based on the MIME type of the response
		/// (an XML MIME type will yield XML, in 1.4 JSON will yield a JavaScript object,
		/// in 1.4 script will execute the script, and anything else will be returned as a string).
		/// </summary>
		public virtual AjaxDataType DataType
		{
			set { dataType = value.ToString(); }
		}

		/// <summary>
		/// Set a timeout (in milliseconds) for the request.
		/// This will override any global timeout set with $.ajaxSetup().
		/// The timeout period starts at the point the <see cref="JQuery.Ajax"/> call is made;
		/// if several other requests are in progress and the browser has no connections available,
		/// it is possible for a request to time out before it can be sent.
		/// <para>This property is a setter for <see cref="timeoutString"/>.</para>
		/// </summary>
		public TimeSpan Timeout
		{
			get
			{
				if (string.IsNullOrEmpty(timeoutString))
					throw new InvalidOperationException("Timeout was not set");

				var timeout = timeoutString.As<double?>();
				if (timeout != null)
					return TimeSpan.FromMilliseconds(timeout.Value);

				throw new InvalidOperationException("Timeout is invalid");
			}
			set { timeoutString = value.TotalMilliseconds.ToString(); }
		}

		/// <summary>
		/// The type of request to make (e.g. "POST", "GET", "PUT"); default is "GET".
		/// </summary>
		public Method Method
		{
			set { type = value.ToString(); }
			get { return type.TryGet<Method>() ?? Method.GET; }
		}

		/// <summary>
		/// This object will be the context of all Ajax-related callbacks.
		/// By default, the context is an object that represents the ajax settings used in the call
		/// ($.ajaxSettings merged with the settings passed to <see cref="JQuery.Ajax"/>).
		/// </summary>
		public HTMLElement Context
		{
			get { return context; }
			set { context = value; }
		}

		/// <summary>
		/// By default, all requests are sent asynchronously (i.e. this is set to <value>true</value> by default).
		/// If you need synchronous requests, set this option to <value>false</value>.
		/// <para>Cross-domain requests and dataType: "jsonp" requests do not support synchronous operation.</para>
		/// <para>Note that synchronous requests may temporarily lock the browser, disabling any actions while the request is active.</para>
		/// </summary>
		public bool IsAsync
		{
			get { return isAsync; }
			set { isAsync = value; }
		}

		/// <summary>
		/// If set to <value>false</value>, it will force requested pages not to be cached by the browser.
		/// <para>Note: Setting cache to false will only work correctly with HEAD and GET requests.
		/// It works by appending "_={timestamp}" to the GET parameters.
		/// The parameter is not needed for other types of requests,
		/// except in IE8 when a POST is made to a URL that has already been requested by a GET.</para>
		/// </summary>
		public bool IsCached
		{
			get { return isCached; }
			set { isCached = value; }
		}

		public Action<JqXHR, AjaxSettings> BeforeSend
		{
			get { return beforeSend; }
			set { beforeSend = value; }
		}

		/// <summary>
		/// A function to be called when the request finishes
		/// (after <see cref="OnSuccessDynamic"/> and <see cref="OnError"/> callbacks are executed).
		/// The function gets passed two arguments:
		/// The <see cref="JqXHR"/> object and a string categorizing the status of the request
		/// ("success", "notmodified", "nocontent", "error", "timeout", "abort", or "parsererror"). 
		/// </summary>
		public Action<JqXHR, string> OnComplete
		{
			get { return onComplete; }
			set { onComplete = value; }
		}

		/// <summary>
		/// If you wish to force a crossDomain request (such as JSONP) on the same domain, set the value of crossDomain to true.
		/// <para>This allows, for example, server-side redirection to another domain.</para>
		/// </summary>
		public bool IsCrossDomain
		{
			get { return isCrossDomain; }
			set { isCrossDomain = value; }
		}

		/// <summary>
		/// Data to be sent to the server. It is converted to a query string.
		/// <para>It's appended to the url for GET-requests.</para>
		/// </summary>
		public Dictionary<string, string> Data
		{
			get { return data.As<Dictionary<string, string>>(); }
			set
			{
				data = new JsArray();

				foreach (var element in value)
				{
					var resultValue = new JsObject();
					((dynamic)resultValue).name = element.Key;
					((dynamic)resultValue).value = element.Value;

					data.push(resultValue);
				}
			}
		}

		/// <summary>
		/// A function to be called if the request fails.
		/// The function receives three arguments: The jqXHR object, a string describing the type of error that occurred
		/// and an optional exception object, if one occurred.
		/// When an HTTP error occurs, errorThrown receives the textual portion of the HTTP status,
		/// such as "Not Found" or "Internal Server Error."
		/// </summary>
		public Action<JqXHR, AjaxErrorTextStatus?, string> OnError
		{
			get { return onError; }
			set { onError = value; }
		}

		/// <summary>
		/// Whether to trigger global Ajax event handlers for this request. The default is <c>true</c>.
		/// Set to <c>false</c> to prevent the global handlers like ajaxStart or ajaxStop from being triggered.
		/// This can be used to control various Ajax Events.
		/// </summary>
		public bool UseGlobalAjaxEventHandlers
		{
			get { return useGlobalAjaxEventHandlers; }
			set { useGlobalAjaxEventHandlers = value; }
		}

		/// <summary>
		/// An object of additional header key/value pairs to send along with requests using the XMLHttpRequest transport.
		/// The header <code>X-Requested-With: XMLHttpRequest</code> is always added,
		/// but its default XMLHttpRequest value can be changed here.
		/// Values in the headers setting can also be overwritten from within the <see cref="beforeSend"/> function.
		/// </summary>
		public Dictionary<string, string> Headers
		{
			get { return headers; }
			set { headers = value; }
		}

		/// <summary>
		/// A string containing the URL to which the request is sent.
		/// </summary>
		public string Url
		{
			get { return url; }
			set { url = value; }
		}

		/// <summary>
		/// A username to be used with XMLHttpRequest in response to an HTTP access authentication request.
		/// </summary>
		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		/// <summary>
		/// A password to be used with XMLHttpRequest in response to an HTTP access authentication request.
		/// </summary>
		public string Password
		{
			get { return password; }
			set { password = value; }
		}
	}
}