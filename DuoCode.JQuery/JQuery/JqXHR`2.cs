using System;

namespace DuoCode.JQuery
{
    public class JqXHR<TResponse, TDeserializer> : JqXHR
        where TDeserializer : Deserializer<TResponse>, new()
    {
        /// <summary>
        /// An alternative construct to the success callback option, the <see cref="OnDone"/> method replaces
        /// the deprecated jqXHR.success() method.
        /// <para>Refer to deferred.done() for implementation details.</para>
        /// </summary>
        public Action<TResponse, string, JqXHR> OnDone { get; set; }

        public JqXHR()
        {
            OnDoneDynamic = (data, textStatus, jqXHR) =>
            {
                var result = DeserializationUtility.Deserialize<TResponse, TDeserializer>(responseText);
                OnDone(result, textStatus, jqXHR);
            };
        }
    }
}