using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    public static class Jsonp
    {
        private static readonly Random _random = new Random();

        public static void Request(JsonpOptions options)
        {
            options.BeforeRequest();

            HTMLScriptElement script = Global.document.createElement("script");

            var callbackName = "jsonp_callback_" + _random.Next();

            script.src = options.Url + (options.Url.Contains("?") ? "&" : "?") + "callback=" + callbackName;
            script.onerror = e =>
            {
                options.OnError(e);
                return null;
            };

            ((dynamic) Global.window)[callbackName] = (Action<object>)(data =>
            {
                Global.window.Eval(string.Format("delete window['{0}'];", callbackName));
                Global.document.body.removeChild(script);

                var result = data.As<JSON>();//DeserializeJsopn(options.OnDeserializationException, data.As<JSON>());

                options.OnSuccess(result);
            });

            Global.document.body.appendChild(script);
        }

        /*private static TResponse DeserializeJsopn(
            Action<string, DeserializationException> onDeserializationException,
            string responseText)
        {
            var deserializer = new TDeserializer();
            var result = default(TResponse);
            try
            {
                result = deserializer.Deserialize(responseText);
            }
            catch (DeserializationException exception)
            {
                onDeserializationException(responseText, exception);
            }
            return result;
        }*/
    }
}
