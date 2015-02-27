using System;
using DuoCode.Dom;
using DuoCode.Helpers;

namespace DuoCode.JQuery
{
    public class AjaxOptions<T>
    {
        public Action<Event, XMLHttpRequest> OnError;
        public Action<Event, T> OnSuccess { get; set; }
        public Action BeforeRequest { get; set; }
        public string Url { get; set; }
        public Method Method { get; set; }
        public Action<Event, string, DeserializationException> OnDeserializationException { get; set; }
    }
}
