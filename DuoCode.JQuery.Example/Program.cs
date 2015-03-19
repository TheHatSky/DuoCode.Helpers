using System;
using System.Linq;
using DuoCode.Dom;
using DuoCode.Helpers;

namespace DuoCode.JQuery
{
    static class Program
    {
        static void RunJQuery() // HTML body.onload event entry point, see index.html
        {
            var a = JQuery.ForSelector("div");

            foreach (HTMLElement item in a)
            {
                Global.console.log(JQuery.FromElements(item).Selector);
                item.innerHTML = "<p>asdasd</p>";
            }

            a.FadeOut(TimeSpan.FromSeconds(4)).Html("LOL");

            /*Global.console.log(divs.AnyHasClass("a"));
            Global.console.log(divs.AllHasClass("a"));
            Global.console.log(divs.AnyDontHasClass("a"));
            Global.console.log(divs.AllDontHasClass("a"));*/
        }

        static void RunAjax() // HTML body.onload event entry point, see index.html
        {
            var el = JQuery.FromElements(Global.document.getElementById("content"));

            var options = new AjaxSettings<HTMLElement, HtmlElementDeserializer>
            {
                Method = Method.GET,
                Url = "http://localhost:19308",
                BeforeSend = (jqXhr, ajaxSettings) =>
                {
                    el.FadeOut(0);
                },
                OnSuccess = (htmlElement, textStatus, jqXhr) =>
                {
                    Global.console.log(htmlElement);
                }
            };

            JQuery.Ajax(options);
        }

        static void RunAjaxJsonp() // HTML body.onload event entry point, see index.html
        {
            var input = Global.document.getElementById("inp") as HTMLInputElement;
            var button = Global.document.getElementById("btn");

            button.onclick = @event =>
            {
                var options = new JsonpOptions<Md5HashInfo>
                {
                    Url = input == null
                        ? string.Empty
                        : input.value ?? string.Empty,
                    OnSuccess = json =>
                    {
                        json.Foo();
                    }
                };

                Jsonp.Request(options);

                return null;
            };
        }
    }
}
