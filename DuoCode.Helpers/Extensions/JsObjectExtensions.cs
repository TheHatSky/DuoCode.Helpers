using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    public static class JsObjectExtensions
    {
        public static T Cast<T>(this JsObject jsObject)
            where T : new()
        {
            var result = new T();

            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var jsAttributes = propertyInfo.GetCustomAttributes(typeof(JsonNameAttribute), false);
                if (jsAttributes.Count > 0)
                {
                    propertyInfo.SetValue(
                        result,
                        jsObject[jsAttributes[0].As<JsonNameAttribute>().Name]);
                }
            }

            return result;
        }
    }
}
