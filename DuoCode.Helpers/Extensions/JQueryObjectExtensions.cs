using System;

namespace DuoCode.Helpers
{
    public static class JQueryObjectExtensions
    {
        public static JQueryObject FadeOut(this JQueryObject source, TimeSpan duration, Action onComplete = null)
        {
            return source.FadeOut(duration.TotalMilliseconds, onComplete);
        }

        public static JQueryObject FadeIn(this JQueryObject source, TimeSpan duration, Action onComplete = null)
        {
            return source.FadeIn(duration.TotalMilliseconds, onComplete);
        }
    }
}
