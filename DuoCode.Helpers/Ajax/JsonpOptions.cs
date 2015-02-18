using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    public class JsonpOptions<TRequest>
    {
        public Action<Event> OnError;
        public Action<TRequest> OnSuccess { get; set; }
        public Action BeforeRequest { get; set; }
        public string Url { get; set; }
        public Action<string, DeserializationException> OnDeserializationException { get; set; }

        public JsonpOptions()
        {
            OnError = e => { };
            OnSuccess = t => { };
            BeforeRequest = () => { };
            OnDeserializationException = (data, exception) =>
            {
                Global.console.log(
                    string.Format(
                        "Unable to deserialize: {0}. Data: {1}",
                        exception.Message,
                        data));
            };
        }
    }
}
