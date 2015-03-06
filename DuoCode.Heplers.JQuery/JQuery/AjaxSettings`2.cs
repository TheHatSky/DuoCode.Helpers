using System;

namespace DuoCode.JQuery
{
	public class AjaxSettings<TResponse, TDeserializer> : AjaxSettings
		where TResponse : new()
		where TDeserializer : Deserializer<TResponse>, new()
	{
		public Action<string, DeserializationException> OnDeserializationException { protected get; set; }

		public sealed override AjaxDataType DataType
		{
			set { }
		}

		/// <summary>
		/// A function to be called if the request succeeds.
		/// The function gets passed three arguments:
		/// The data returned from the server;
		/// a string describing the status;
		/// and the jqXHR object.
		/// </summary>
		public Action<TResponse, string, JqXHR<TResponse, TDeserializer>> OnSuccess { get; set; }

		public AjaxSettings()
		{
			DataType = AjaxDataType.text;

			OnSuccessDynamic = (data, textStatus, jqXHR) =>
			{
				var responseText = jqXHR.responseText;
				try
				{
					var deserializedData = DeserializationUtility.Deserialize<TResponse, TDeserializer>(responseText);
					OnSuccess(deserializedData, textStatus, jqXHR as JqXHR<TResponse, TDeserializer>);
				}
				catch (DeserializationException exception)
				{
					OnDeserializationException(responseText, exception);
				}
			};
		}
	}
}
