using System;
using DuoCode.Dom;

namespace DuoCode.JQuery
{
    public static class WindowExtensions
    {
        public static void Eval(
            this Window window,
            string code)
        {
            if (window == null)
                throw new ArgumentNullException("window");
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code");

            ((dynamic) window).eval(code);
        }
    }
}
