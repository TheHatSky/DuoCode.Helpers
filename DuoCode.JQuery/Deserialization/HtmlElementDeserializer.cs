﻿using DuoCode.Dom;

namespace DuoCode.JQuery
{
    /// <summary>
    /// Wraps html with <c>div</c> tag.
    /// <para>Ignores <c>html</c> and <c>body</c> tags.</para>
    /// </summary>
    public class HtmlElementDeserializer : Deserializer<HTMLElement>
    {
        protected override HTMLElement GetObject()
        {
            return Global.document.createElement("div");
        }

        public override HTMLElement Deserialize(string text)
        {
            var element = GetObject();
            element.innerHTML = text;

            return element;
        }
    }
}