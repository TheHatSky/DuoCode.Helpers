using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace HelloDuoCode
{
    public static class JQuery
    {
        private static readonly dynamic Jquery;

        public static JQueryObject Get(string selector)
        {
            var elements = (JsArray)Jquery(selector);

            var result = new JQueryObject();

            foreach (var element in elements)
                result.Add(element.As<HTMLElement>());

            return result;
        }

        public static JQueryObject Get(params HTMLElement[] htmlElements)
        {
            return new JQueryObject(htmlElements);
        }

        static JQuery()
        {
            Jquery = ((dynamic) Global.window).jQuery;

            if (Jquery == null)
                throw new InvalidOperationException("jQuery is not loaded");
        }
    }
}