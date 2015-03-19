using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
	public class JsonAjaxSettings<TResponse> : AjaxSettings<TResponse, JsonDeserializer<TResponse>>
		where TResponse : new()
	{
		public JsonAjaxSettings()
		{
			DataType = AjaxDataType.json;
			OnSuccessDynamic = (data, textStatus, jqXHR) =>
			{
				try
				{
					var responseText = jqXHR.responseText;
					var result = (jqXHR.responseJSON ?? (JsObject)(Global.JSON.parse(responseText))).As<TResponse>();

					OnSuccess(result, textStatus, jqXHR as JqXHR<TResponse, JsonDeserializer<TResponse>>);
				}
				catch (DeserializationException exception)
				{
					OnDeserializationException(jqXHR.response, exception);
				}
			};
		}
	}
}
