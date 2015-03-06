using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
	public class JsonAjaxSettings<TResponse> : AjaxSettings<TResponse, JsonDeserializer<TResponse>>
		where TResponse : new()
	{
		public JsonAjaxSettings()
		{
			OnSuccessDynamic = (data, textStatus, jqXHR) =>
			{
				var responseText = jqXHR.responseText;
				try
				{
					var jsObject = (JsObject)(Global.JSON.parse(responseText));
					var result = jsObject.Cast<TResponse>();
					OnSuccess(result, textStatus, jqXHR as JqXHR<TResponse, JsonDeserializer<TResponse>>);
				}
				catch (DeserializationException exception)
				{
					OnDeserializationException(responseText, exception);
				}
			};
		}
	}
}
