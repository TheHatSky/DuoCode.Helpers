using System;

using DuoCode.Runtime;

namespace DuoCode.JQuery
{
	public static class JsObjectExtensions
	{
		public static T Cast<T>(this JsObject json)
			where T : new()
		{
			var result = new T();

			foreach (var propertyInfo in typeof(T).GetProperties())
			{
				var jsonAttributes = propertyInfo.GetCustomAttributes(typeof(JsonNameAttribute), false);
				if (jsonAttributes.Count > 0)
				{
					propertyInfo.SetValue(
						result,
						json[jsonAttributes[0].As<JsonNameAttribute>().Name]);
				}
			}

			return result;
		}
	}
}
