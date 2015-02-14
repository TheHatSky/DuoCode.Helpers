using System;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace HelloDuoCode.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class HTMLElementExtensions
    {
        private const int TimeBetweenSteps = 40;

        public static void Fade(this HTMLElement element, TimeSpan fadingTime, double initialOpacity)
        {
            if (element.style.opacity.As<double>() <= 0 || fadingTime.TotalMilliseconds <= .01)
            {
                element.style.display = "none";
                return;
            }

            var shadeStep = initialOpacity / (fadingTime.TotalMilliseconds / TimeBetweenSteps);

            element.style.opacity = (element.style.AsDouble(s => s.opacity) - shadeStep).ToString();

            Global.window.setTimeout(
                (Action)(
                    () => Fade(element, fadingTime, initialOpacity)),
                TimeBetweenSteps);
        }

        public static void Show(
            this HTMLElement element,
            TimeSpan fadingTime,
            double initialOpacity,
            string display = null)
        {
            if (element.style.opacity.As<double>() <= 0)
            {
                element.style.opacity = "0";
                element.style.display = display ?? "block";
            }

            if (element.style.opacity.As<double>() >= 1 || fadingTime.TotalMilliseconds <= .01)
                return;

            var shadeStep = (1 - initialOpacity) / (fadingTime.TotalMilliseconds / TimeBetweenSteps);

            // BUG
            element.style.opacity = (shadeStep + element.style.AsDouble(s => s.opacity)).ToString();

            Global.window.setTimeout(
                (Action)(
                    () => Show(element, fadingTime, initialOpacity)),
                TimeBetweenSteps);
        }
    }
}