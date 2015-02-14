using System;
using System.Collections.Generic;
using System.Linq;
using DuoCode.Dom;
using DuoCode.Runtime;
using HelloDuoCode.Extensions;

namespace HelloDuoCode
{
    public class JQueryObject : List<HTMLElement>
    {
        public JQueryObject()
        {
        }

        public JQueryObject(IEnumerable<HTMLElement> elements)
            : this()
        {
            foreach (var element in elements)
                Add(element);
        }

        public JQueryObject(params HTMLElement[] elements)
            : this(elements.ToList())
        {
        }

        public JQueryObject Css(Action<MSStyleCSSProperties> setter)
        {
            foreach (var element in this)
                setter(element.style);

            return this;
        }

        public JQueryObject Attr(string attributeName, Func<string, string> valueBuilder)
        {
            foreach (var element in this)
            {
                var value = element.getAttribute(attributeName);
                element.setAttribute(attributeName, valueBuilder(value));
            }

            return this;
        }

        public JQueryObject Attr(string attributeName, string value)
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

        public JQueryObject AddClass(string className)
        {
            foreach (var element in this)
                if (!element.classList.contains(className))
                    element.classList.add_(className);

            return this;
        }

        public JQueryObject RemoveClass(string className)
        {
            foreach (var element in this)
                if (element.classList.contains(className))
                    element.classList.remove_(className);

            return this;
        }

        public JQueryObject ToggleClass(string className)
        {
            foreach (var element in this)
                if (element.classList.contains(className))
                    element.classList.remove_(className);
                else
                    element.classList.add_(className);

            return this;
        }

        public JQueryObject WithClass(string className)
        {
            return new JQueryObject(this.Where(e => e.classList.contains(className)));
        }

        public JQueryObject WithoutClass(string className)
        {
            return new JQueryObject(this.Where(e => !e.classList.contains(className)));
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

        public JQueryObject Fade(int fadingTimeInMilliseconds = 400)
        {
            return Fade(TimeSpan.FromMilliseconds(fadingTimeInMilliseconds));
        }

        public JQueryObject Fade(TimeSpan fadingTime)
        {
            foreach (var element in this)
            {
                element.style.opacity = element.style.opacity ?? "1"; 
                element.Fade(fadingTime, element.style.opacity.As<double>());
            }

            return this;
        }

        public JQueryObject Show(int showingTimeInMilliseconds = 400, string display = null)
        {
            return Show(TimeSpan.FromMilliseconds(showingTimeInMilliseconds));
        }

        public JQueryObject Show(TimeSpan showingTime, string display = null)
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
