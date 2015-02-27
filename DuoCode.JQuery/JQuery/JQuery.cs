using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
    [Js(Name = "$", Extern = true)]
    public static class JQuery
    {
        [Js(Name = "fn.init")]
        public static extern JQueryObject ForSelector(string selector, string wrapper = null);

        [Js(Name = "fn.init")]
        public static extern JQueryObject FromElements(params HTMLElement[] elements);

        [Js(Name = "ajax")]
        public static extern JqXHR Ajax(AjaxSettings settings);

        [Js(Name = "ajax")]
        public static extern JqXHR Ajax<TResponce, TDeserializer>(AjaxSettings<TResponce, TDeserializer> settings)
            where TDeserializer : Deserializer<TResponce>, new()
            where TResponce : new();
    }
}
