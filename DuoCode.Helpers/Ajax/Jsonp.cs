using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    public static class Jsonp
    {
        private static readonly Random _random = new Random();

        public static void Request<TRequest>(JsonpOptions<TRequest> options)
            where TRequest : new()
        {
            options.BeforeRequest();

            HTMLScriptElement script = Global.document.createElement("script");

            var callbackName = "jsonp_callback_" + _random.Next();

            script.src = options.Url + (options.Url.Contains("?") ? "&" : "?") + "callback=" + callbackName;
            script.onerror = e =>
            {
                options.OnError(e);
                Global.window.Eval(string.Format("delete window['{0}'];", callbackName));
                return null;
            };

            ((dynamic) Global.window)[callbackName] = (Action<JsObject>)(data =>
            {
                Global.window.Eval(string.Format("delete window['{0}'];", callbackName));
                Global.document.body.removeChild(script);

                var result = data.Cast<TRequest>();

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
