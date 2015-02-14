using System;
using System.Drawing;
using System.Linq;
using DuoCode.Dom;
//using static DuoCode.Dom.Global; // uncomment to use C# 6.0 'using static' syntax

namespace HelloDuoCode
{
    static class Program
    {
        public class Greeter
        {
            private readonly HTMLElement span;
            private int timerToken;

            public Greeter(HTMLElement el)
            {
                span = Global.document.createElement("span");
                el.appendChild(span);
                Tick();
            }

            public void Start()
            {
                timerToken = Global.window.setInterval((Action)Tick, 500);
            }

            public void Stop()
            {
                Global.window.clearTimeout(timerToken);
            }

            private void Tick()
            {
                span.innerHTML = string.Format("The time is: {0}", DateTime.Now); // try to put a breakpoint here
            }
        }

        static void Run() // HTML body.onload event entry point, see index.html
        {
            var el = Global.document.getElementById("content");
            var greeter = new Greeter(el);
            greeter.Start();

            var z = JQuery.Get("div").WithoutClass("a").Show(10000);

            Global.console.log(z.AnyHasClass("a"));
            Global.console.log(z.AllHasClass("a"));
            Global.console.log(z.AnyDontHasClass("a"));
            Global.console.log(z.AllDontHasClass("a"));
        }
    }
}
