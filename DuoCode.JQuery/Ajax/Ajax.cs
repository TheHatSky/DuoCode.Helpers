﻿using System;
using DuoCode.Dom;
using DuoCode.Helpers;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
    public static class Ajax<TResponse, TDeserializer>
        where TResponse : new()
        where TDeserializer : Deserializer<TResponse>, new()
    {
        public static Action<Event, string, DeserializationException> DefaultOnDeserializationException { private get; set; }
        public static Action<Event, TResponse> DefaultOnSuccess { private get; set; }

        static Ajax()
        {
            DefaultOnDeserializationException =
                (e, responseText, exception) =>
                {
                    Global.console.log("Deserialization error: " + responseText);
                };

            DefaultOnSuccess =
                (e, response) => Global.console.log(response);
        }

        private static void DefaultOnError(Event e, XMLHttpRequest xmlHttpRequest)
        {
            Global.window.alert(
                string.Format("Error with status {0}: {1}.", xmlHttpRequest.status, xmlHttpRequest.statusText));
        }

        public static void Request(
            Method method,
            string url,
            Action<Event, TResponse> onSuccess = null,
            Action<Event, string, DeserializationException> onDeserializationException = null,
            Action<Event, XMLHttpRequest> onError = null,
            Action beforeRequest = null)
        {
            onSuccess = onSuccess ?? DefaultOnSuccess;
            onDeserializationException = onDeserializationException ?? DefaultOnDeserializationException;
            onError = onError ?? DefaultOnError;

            var xmlHttpRequest = new XMLHttpRequest();
            xmlHttpRequest.open(method.As<string>(), url, true);

            xmlHttpRequest.onreadystatechange = e =>
            {
                if (xmlHttpRequest.readyState == (ushort)AjaxRequestReadyState.ResponseReady)
                {
                    if (xmlHttpRequest.status != 200)
                        onError(e, xmlHttpRequest);

                    var result = Deserialize(onDeserializationException, xmlHttpRequest.responseText, e);
                    onSuccess(e, result);

                    return null;
                }

                return null;
            };

            if (beforeRequest != null)
                beforeRequest();

            xmlHttpRequest.send();
        }

        private static TResponse Deserialize(
            Action<Event, string, DeserializationException> onDeserializationException,
            string responseText,
            Event e)
        {
            var deserializer = new TDeserializer();
            var result = default(TResponse);
            try
            {
                result = deserializer.Deserialize(responseText);
            }
            catch (DeserializationException exception)
            {
                onDeserializationException(e, responseText, exception);
            }
            return result;
        }


        public static void Request(AjaxOptions<TResponse> options)
        {
            Request(
                options.Method,
                options.Url,
                onSuccess: options.OnSuccess,
                onDeserializationException: options.OnDeserializationException,
                onError: options.OnError,
                beforeRequest: options.BeforeRequest
                );
        }
    }


    public static class Ajax<TResponse>
        where TResponse : new()
    {
        public static Action<Event, string, DeserializationException> DefaultOnDeserializationException { private get; set; }
        public static Action<Event, TResponse> DefaultOnSuccess { private get; set; }

        static Ajax()
        {
            DefaultOnDeserializationException =
                (e, responseText, exception) =>
                {
                    Global.console.log("Deserialization error: " + responseText);
                };

            DefaultOnSuccess =
                (e, response) => Global.console.log(response);
        }

        private static void DefaultOnError(Event e, XMLHttpRequest xmlHttpRequest)
        {
            Global.window.alert(
                string.Format("Error with status {0}: {1}.", xmlHttpRequest.status, xmlHttpRequest.statusText));
        }

        public static void Request(
            Method method,
            string url,
            Action<Event, TResponse> onSuccess = null,
            Action<Event, string, DeserializationException> onDeserializationException = null,
            Action<Event, XMLHttpRequest> onError = null,
            Action beforeRequest = null)
        {
            onSuccess = onSuccess ?? DefaultOnSuccess;
            onDeserializationException = onDeserializationException ?? DefaultOnDeserializationException;
            onError = onError ?? DefaultOnError;

            var xmlHttpRequest = new XMLHttpRequest();
            xmlHttpRequest.open(method.As<string>(), url, true);

            xmlHttpRequest.onreadystatechange = e =>
            {
                if (xmlHttpRequest.readyState == (ushort)AjaxRequestReadyState.ResponseReady)
                {
                    if (xmlHttpRequest.status != 200)
                        onError(e, xmlHttpRequest);

                    var result = Deserialize(onDeserializationException, xmlHttpRequest.responseText, e);
                    onSuccess(e, result);

                    return null;
                }

                return null;
            };

            if (beforeRequest != null)
                beforeRequest();

            xmlHttpRequest.send();
        }

        private static TResponse Deserialize(
            Action<Event, string, DeserializationException> onDeserializationException,
            string responseText,
            Event e)
        {
            var deserializer = new JsonDeserializer<TResponse>();
            var result = default(TResponse);
            try
            {
                result = deserializer.Deserialize(responseText);
            }
            catch (DeserializationException exception)
            {
                onDeserializationException(e, responseText, exception);
            }
            return result;
        }


        public static void Request(AjaxOptions<TResponse> options)
        {
            Request(
                options.Method,
                options.Url,
                onSuccess: options.OnSuccess,
                onDeserializationException: options.OnDeserializationException,
                onError: options.OnError,
                beforeRequest: options.BeforeRequest
                );
        }
    }
}
