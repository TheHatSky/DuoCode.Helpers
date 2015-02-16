using DuoCode.Dom;

namespace DuoCode.Helpers
{
    static class Program
    {
        static void RunJQuery() // HTML body.onload event entry point, see index.html
        {
            var divs = JQuery.Get("div").WithoutClass("a").Show(10000);

            Global.console.log(divs.AnyHasClass("a"));
            Global.console.log(divs.AllHasClass("a"));
            Global.console.log(divs.AnyDontHasClass("a"));
            Global.console.log(divs.AllDontHasClass("a"));
        }

        static void RunAjax() // HTML body.onload event entry point, see index.html
        {
            var el = JQuery.Get(Global.document.getElementById("content"));

            var options = new AjaxOptions<HTMLElement>
            {
                Method = Method.GET,
                Url = "http://localhost:19308",
                BeforeRequest = () =>
                {
                    el.Fade(0);
                },
                OnSuccess = (e, element) =>
                {
                    el.Html(element.innerHTML, true).Show(4000);
                }
            };

            Ajax<HTMLElement, HtmlElementDeserializer>.Request(options);
        }

        static void RunAjaxJsonp() // HTML body.onload event entry point, see index.html
        {
            var input = Global.document.getElementById("inp") as HTMLInputElement;
            var button = Global.document.getElementById("btn");

            button.onclick = @event =>
            {
                var options = new JsonpOptions
                {
                    Url = input == null
                        ? string.Empty
                        : input.value ?? string.Empty,
                    OnSuccess = json =>
                    {
                        Global.console.log(json);
                    }
                };

                Jsonp.Request(options);

                return null;
            };
        }
    }
}
