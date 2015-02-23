using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    [Obsolete]
    public static class VanillaJQuery
    {
        private static readonly dynamic Jquery;

        public static VanillaJQueryObject Get(string selector)
        {
            var elements = (JsArray)Jquery(selector);

            var result = new VanillaJQueryObject();

            foreach (var element in elements)
                result.Add(element.As<HTMLElement>());

            return result;
        }

        public static VanillaJQueryObject Get(params HTMLElement[] htmlElements)
        {
            return new VanillaJQueryObject(htmlElements);
        }

        static VanillaJQuery()
        {
            Jquery = ((dynamic) Global.window).jQuery;

            if (Jquery == null)
                throw new InvalidOperationException("jQuery is not loaded");
        }
    }
}