using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
    public static class HtmlElementExtensions
    {
        private const int MillisecondsBetweenSteps = 40;

        public static void Fade(this HTMLElement element, TimeSpan fadingTime, double initialOpacity)
        {
            if (fadingTime.TotalMilliseconds <= 0.1)
            {
                element.style.opacity = "0";
                element.style.display = "none";

                return;
            }

            if (element.style.opacity.As<double>() <= 0)
            {
                element.style.display = "none";
                return;
            }

            var shadeStep = initialOpacity / (fadingTime.TotalMilliseconds / MillisecondsBetweenSteps);

            element.style.opacity = (element.style.AsDouble(s => s.opacity) - shadeStep).ToString();

            Global.window.setTimeout(
                (Action)(
                    () => Fade(element, fadingTime, initialOpacity)),
                MillisecondsBetweenSteps);
        }

        public static void Show(
            this HTMLElement element,
            TimeSpan showingTime,
            double initialOpacity,
            string display = null)
        {
            if (showingTime.TotalMilliseconds <= 0.1)
            {
                element.style.opacity = "1";
                element.style.display = display ?? "block";

                return;
            }

            if (element.style.opacity.As<double>() <= 0)
                element.style.opacity = "0";

            if (element.style.opacity.As<double>() > 0)
                element.style.display = display ?? "block";

            if (element.style.opacity.As<double>() >= 1)
                return;

            var shadeStep = (1 - initialOpacity) / (showingTime.TotalMilliseconds / MillisecondsBetweenSteps);

            // BUG As<double> is string
            element.style.opacity = (shadeStep + element.style.AsDouble(s => s.opacity)).ToString();

            Global.window.setTimeout(
                (Action)(
                    () => Show(element, showingTime, initialOpacity)),
                MillisecondsBetweenSteps);
        }
    }
}