using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace HelloDuoCode.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class CssStyleDeclarationExtensions
    {
        public static double AsDouble(
            this CSSStyleDeclaration source,
            Func<CSSStyleDeclaration, string> getter)
        {
            return getter(source).As<double>() * 1;
        }

        public static double AsInt32(
            this CSSStyleDeclaration source,
            Func<CSSStyleDeclaration, string> getter)
        {
            return getter(source).As<int>() * 1;
        }
    }
}
