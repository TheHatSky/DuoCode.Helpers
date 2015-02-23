using System;
using System.Collections.Generic;
using System.Linq;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    [Obsolete]
    public class VanillaJQueryObject : List<HTMLElement>
    {
        public VanillaJQueryObject()
        {
        }

        public VanillaJQueryObject(IEnumerable<HTMLElement> elements)
            : this()
        {
            foreach (var element in elements)
                Add(element);
        }

        public VanillaJQueryObject(params HTMLElement[] elements)
            : this(elements.ToList())
        {
        }

        public VanillaJQueryObject Css(Action<MSStyleCSSProperties> setter)
        {
            foreach (var element in this)
                setter(element.style);

            return this;
        }

        public VanillaJQueryObject Attr(string attributeName, Func<string, string> valueBuilder)
        {
            foreach (var element in this)
            {
                var value = element.getAttribute(attributeName);
                element.setAttribute(attributeName, valueBuilder(value));
            }

            return this;
        }

        public VanillaJQueryObject Attr(string attributeName, string value)
        {
            return Attr(attributeName, v => value);
        }

        /// <summary>
        /// Returns given attribute's value of first possible element.
        /// <para>If there are no elements in <c>JQueryObject</c>, returns <value>null</value>.</para>
        /// </summary>
        public string Attr(string attributeName)
        {
            return this.Any()
                ? this[0].getAttribute(attributeName)
                : null;
        }

        public VanillaJQueryObject Text(string text)
        {
            foreach (var element in this)
                element.innerText = text;

            return this;
        }

        public VanillaJQueryObject Html(string html, bool evaluateScripts = false)
        {
            foreach (var element in this)
            {
                element.innerHTML = html;
                if (!evaluateScripts)
                    continue;

                for (int i = 0; i < element.children.length; i++)
                {
                    var child = element.children[i] as HTMLScriptElement;
                    if (child != null)
                        ((dynamic) Global.window).eval(child.innerText);
                }
            }

            return this;
        }

        public VanillaJQueryObject AddClass(string className)
        {
            foreach (var element in this)
                if (!element.classList.contains(className))
                    element.classList.add_(className);

            return this;
        }

        public VanillaJQueryObject RemoveClass(string className)
        {
            foreach (var element in this)
                if (element.classList.contains(className))
                    element.classList.remove_(className);

            return this;
        }

        public VanillaJQueryObject ToggleClass(string className)
        {
            foreach (var element in this)
                if (element.classList.contains(className))
                    element.classList.remove_(className);
                else
                    element.classList.add_(className);

            return this;
        }

        public VanillaJQueryObject WithClass(string className)
        {
            return new VanillaJQueryObject(this.Where(e => e.classList.contains(className)));
        }

        public VanillaJQueryObject WithoutClass(string className)
        {
            return new VanillaJQueryObject(this.Where(e => !e.classList.contains(className)));
        }

        public bool AnyHasClass(string className)
        {
            return this.Any(e => e.classList.contains(className));
        }

        public bool AllHasClass(string className)
        {
            return this.All(e => e.classList.contains(className));
        }

        public bool AnyDontHasClass(string className)
        {
            return !AllHasClass(className);
        }

        public bool AllDontHasClass(string className)
        {
            return !AnyHasClass(className);
        }

        public VanillaJQueryObject Fade(int fadingTimeInMilliseconds = 400)
        {
            return Fade(TimeSpan.FromMilliseconds(fadingTimeInMilliseconds));
        }

        public VanillaJQueryObject Fade(TimeSpan fadingTime)
        {
            foreach (var element in this)
            {
                element.style.opacity = element.style.opacity ?? "1"; 
                element.Fade(fadingTime, element.style.opacity.As<double>());
            }

            return this;
        }

        public VanillaJQueryObject Show(int showingTimeInMilliseconds = 400, string display = null)
        {
            return Show(TimeSpan.FromMilliseconds(showingTimeInMilliseconds));
        }

        public VanillaJQueryObject Show(TimeSpan showingTime, string display = null)
        {
            foreach (var element in this)
            {
                element.style.opacity = element.style.opacity ?? "0";
                element.Show(
                    showingTime,
                    element.style.opacity.As<double>(),
                    display);
            }

            return this;
        }
    }
}
