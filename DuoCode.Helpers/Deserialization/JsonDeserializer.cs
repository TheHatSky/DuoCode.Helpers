using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    public class JsonDeserializer<T> : Deserializer<T>
        where T : new()
    {
        protected override T GetObject()
        {
            throw new InvalidOperationException();
        }

        public override T Deserialize(string source)
        {
            var jsObject = (JsObject)(new JSON().parse(source));
            return jsObject.Cast<T>();
        }
    }
}