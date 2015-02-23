using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    [Js(Name = "$", Extern = true)]
    public static class JQuery
    {
        [Js(Name = "fn.init")]
        public static extern JQueryObject ForSelector(string selector, string wrapper = null);

        [Js(Name = "fn.init")]
        public static extern JQueryObject FromElements(params HTMLElement[] elements);
    }
}
