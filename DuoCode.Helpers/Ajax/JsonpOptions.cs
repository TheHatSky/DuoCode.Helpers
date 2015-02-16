﻿using System;
using DuoCode.Dom;

namespace DuoCode.Helpers
{
    public class JsonpOptions
    {
        public Action<Event> OnError;
        public Action<JSON> OnSuccess { get; set; }
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