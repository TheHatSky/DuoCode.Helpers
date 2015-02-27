using System;

namespace DuoCode.Helpers
{
    public static class StringExtensions
    {
        public static T? TryGet<T>(this string source)
            where T : struct
        {
            if (!typeof(T).IsAssignableFrom(typeof(Enum)))
                throw new InvalidOperationException(
                    string.Format(
                        "Type \"{0}\" is not assignable from Enum",
                        typeof(T).Name));

            T result;
            if (Enum.TryParse(source, out result))
                return result;

            return null;
        }
    }
}
