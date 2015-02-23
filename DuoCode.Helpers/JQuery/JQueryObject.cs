using System;
using System.Collections;
using System.Collections.Generic;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.Helpers
{
    [Js(Name = "$.fn", Extern = true, OptimizeArrayEnumeration = "toArray()")]
    public sealed class JQueryObject : IEnumerable<HTMLElement>
    {
        [Js(Name = "fadeIn")]
        public extern JQueryObject FadeIn(double durationInMilliseconds = 1000, Action onComplete = null);

        [Js(Name = "fadeOut")]
        public extern JQueryObject FadeOut(double durationInMilliseconds = 1000, Action onComplete = null);

        [Js(Name = "jquery")]
        public extern JQueryObject Jquery(dynamic arg0, dynamic arg1, dynamic arg2, dynamic arg3, dynamic arg4);

        [Js(Name = "constructor")]
        public extern JQueryObject Constructor(dynamic arg0, dynamic arg1);

        [Js(Name = "selector")]
        public extern string Selector { get; }

        [Js(Name = "length")]
        public extern int Length { get; }

        [Js(Name = "toArray")]
        public extern JsArray ToArray();

        [Js(Name = "get")]
        public extern JQueryObject Get(dynamic arg0);

        [Js(Name = "pushStack")]
        public extern JQueryObject PushStack(dynamic arg0);

        [Js(Name = "each")]
        public extern JQueryObject Each(dynamic arg0, dynamic arg1);

        [Js(Name = "map")]
        public extern JQueryObject Map(dynamic arg0);

        [Js(Name = "slice")]
        public extern JQueryObject Slice();

        [Js(Name = "first")]
        public extern JQueryObject First();

        [Js(Name = "last")]
        public extern JQueryObject Last();

        [Js(Name = "eq")]
        public extern JQueryObject Eq(dynamic arg0);

        [Js(Name = "end")]
        public extern JQueryObject End();

        [Js(Name = "push")]
        public extern JQueryObject Push(dynamic arg0);

        [Js(Name = "sort")]
        public extern JQueryObject Sort(dynamic arg0);

        [Js(Name = "splice")]
        public extern JQueryObject Splice(dynamic arg0, dynamic arg1);

        [Js(Name = "extend")]
        public extern JQueryObject Extend();

        [Js(Name = "find")]
        public extern JQueryObject Find(dynamic arg0);

        [Js(Name = "filter")]
        public extern JQueryObject Filter(string selector);

        [Js(Name = "not")]
        public extern JQueryObject Not(string selector);

        [Js(Name = "is")]
        public extern JQueryObject Is(string selector);

        [Js(Name = "has")]
        public extern JQueryObject Has(dynamic arg0);

        [Js(Name = "closest")]
        public extern JQueryObject Closest(dynamic arg0, dynamic arg1);

        [Js(Name = "index")]
        public extern JQueryObject Index(dynamic arg0);

        [Js(Name = "add")]
        public extern JQueryObject Add(dynamic arg0, dynamic arg1);

        [Js(Name = "addBack")]
        public extern JQueryObject AddBack(dynamic arg0);

        [Js(Name = "parent")]
        public extern JQueryObject Parent(dynamic arg0, dynamic arg1);

        [Js(Name = "parents")]
        public extern JQueryObject Parents(dynamic arg0, dynamic arg1);

        [Js(Name = "parentsUntil")]
        public extern JQueryObject ParentsUntil(dynamic arg0, dynamic arg1);

        [Js(Name = "next")]
        public extern JQueryObject Next(dynamic arg0, dynamic arg1);

        [Js(Name = "prev")]
        public extern JQueryObject Prev(dynamic arg0, dynamic arg1);

        [Js(Name = "nextAll")]
        public extern JQueryObject NextAll(dynamic arg0, dynamic arg1);

        [Js(Name = "prevAll")]
        public extern JQueryObject PrevAll(dynamic arg0, dynamic arg1);

        [Js(Name = "nextUntil")]
        public extern JQueryObject NextUntil(dynamic arg0, dynamic arg1);

        [Js(Name = "prevUntil")]
        public extern JQueryObject PrevUntil(dynamic arg0, dynamic arg1);

        [Js(Name = "siblings")]
        public extern JQueryObject Siblings(dynamic arg0, dynamic arg1);

        [Js(Name = "children")]
        public extern JQueryObject Children(dynamic arg0, dynamic arg1);

        [Js(Name = "contents")]
        public extern JQueryObject Contents(dynamic arg0, dynamic arg1);

        [Js(Name = "ready")]
        public extern JQueryObject Ready(dynamic arg0);

        [Js(Name = "data")]
        public extern JQueryObject Data(dynamic arg0, dynamic arg1);

        [Js(Name = "removeData")]
        public extern JQueryObject RemoveData(dynamic arg0);

        [Js(Name = "queue")]
        public extern JQueryObject Queue(dynamic arg0, dynamic arg1);

        [Js(Name = "dequeue")]
        public extern JQueryObject Dequeue(dynamic arg0);

        [Js(Name = "clearQueue")]
        public extern JQueryObject ClearQueue(dynamic arg0);

        [Js(Name = "promise")]
        public extern JQueryObject Promise(dynamic arg0, dynamic arg1);

        [Js(Name = "on")]
        public extern JQueryObject On(dynamic arg0, dynamic arg1, dynamic arg2, dynamic arg3, dynamic arg4);

        [Js(Name = "one")]
        public extern JQueryObject One(dynamic arg0, dynamic arg1, dynamic arg2, dynamic arg3);

        [Js(Name = "off")]
        public extern JQueryObject Off(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "trigger")]
        public extern JQueryObject Trigger(dynamic arg0, dynamic arg1);

        [Js(Name = "triggerHandler")]
        public extern JQueryObject TriggerHandler(dynamic arg0, dynamic arg1);

        [Js(Name = "text")]
        public extern JQueryObject Text(dynamic arg0);

        [Js(Name = "append")]
        public extern JQueryObject Append();

        [Js(Name = "prepend")]
        public extern JQueryObject Prepend();

        [Js(Name = "before")]
        public extern JQueryObject Before();

        [Js(Name = "after")]
        public extern JQueryObject After();

        [Js(Name = "remove")]
        public extern JQueryObject Remove(dynamic arg0, dynamic arg1);

        [Js(Name = "empty")]
        public extern JQueryObject Empty();

        [Js(Name = "clone")]
        public extern JQueryObject Clone(dynamic arg0, dynamic arg1);

        [Js(Name = "html")]
        public extern string Html();

        [Js(Name = "html")]
        public extern JQueryObject Html(dynamic arg0);

        [Js(Name = "replaceWith")]
        public extern JQueryObject ReplaceWith();

        [Js(Name = "detach")]
        public extern JQueryObject Detach(dynamic arg0);

        [Js(Name = "domManip")]
        public extern JQueryObject DomManip(dynamic arg0, dynamic arg1);

        [Js(Name = "appendTo")]
        public extern JQueryObject AppendTo(dynamic arg0);

        [Js(Name = "prependTo")]
        public extern JQueryObject PrependTo(dynamic arg0);

        [Js(Name = "insertBefore")]
        public extern JQueryObject InsertBefore(dynamic arg0);

        [Js(Name = "insertAfter")]
        public extern JQueryObject InsertAfter(dynamic arg0);

        [Js(Name = "replaceAll")]
        public extern JQueryObject ReplaceAll(dynamic arg0);

        [Js(Name = "css")]
        public extern JQueryObject Css(dynamic arg0, dynamic arg1);

        [Js(Name = "show")]
        public extern JQueryObject Show(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "hide")]
        public extern JQueryObject Hide(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "toggle")]
        public extern JQueryObject Toggle(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "fadeTo")]
        public extern JQueryObject FadeTo(dynamic arg0, dynamic arg1, dynamic arg2, dynamic arg3);

        [Js(Name = "animate")]
        public extern JQueryObject Animate(dynamic arg0, dynamic arg1, dynamic arg2, dynamic arg3);

        [Js(Name = "stop")]
        public extern JQueryObject Stop(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "finish")]
        public extern JQueryObject Finish(dynamic arg0);

        [Js(Name = "slideDown")]
        public extern JQueryObject SlideDown(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "slideUp")]
        public extern JQueryObject SlideUp(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "slideToggle")]
        public extern JQueryObject SlideToggle(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "fadeIn")]
        public extern JQueryObject FadeIn(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "fadeOut")]
        public extern JQueryObject FadeOut(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "fadeToggle")]
        public extern JQueryObject FadeToggle(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "delay")]
        public extern JQueryObject Delay(dynamic arg0, dynamic arg1);

        [Js(Name = "attr")]
        public extern JQueryObject Attr(dynamic arg0, dynamic arg1);

        [Js(Name = "removeAttr")]
        public extern JQueryObject RemoveAttr(dynamic arg0);

        [Js(Name = "prop")]
        public extern JQueryObject Prop(dynamic arg0, dynamic arg1);

        [Js(Name = "removeProp")]
        public extern JQueryObject RemoveProp(dynamic arg0);

        [Js(Name = "addClass")]
        public extern JQueryObject AddClass(dynamic arg0);

        [Js(Name = "removeClass")]
        public extern JQueryObject RemoveClass(dynamic arg0);

        [Js(Name = "toggleClass")]
        public extern JQueryObject ToggleClass(dynamic arg0, dynamic arg1);

        [Js(Name = "hasClass")]
        public extern JQueryObject HasClass(dynamic arg0);

        [Js(Name = "val")]
        public extern JQueryObject Val(dynamic arg0);

        [Js(Name = "blur")]
        public extern JQueryObject Blur(dynamic arg0, dynamic arg1);

        [Js(Name = "focus")]
        public extern JQueryObject Focus(dynamic arg0, dynamic arg1);

        [Js(Name = "focusin")]
        public extern JQueryObject Focusin(dynamic arg0, dynamic arg1);

        [Js(Name = "focusout")]
        public extern JQueryObject Focusout(dynamic arg0, dynamic arg1);

        [Js(Name = "load")]
        public extern JQueryObject Load(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "resize")]
        public extern JQueryObject Resize(dynamic arg0, dynamic arg1);

        [Js(Name = "scroll")]
        public extern JQueryObject Scroll(dynamic arg0, dynamic arg1);

        [Js(Name = "unload")]
        public extern JQueryObject Unload(dynamic arg0, dynamic arg1);

        [Js(Name = "click")]
        public extern JQueryObject Click(dynamic arg0, dynamic arg1);

        [Js(Name = "dblclick")]
        public extern JQueryObject Dblclick(dynamic arg0, dynamic arg1);

        [Js(Name = "mousedown")]
        public extern JQueryObject Mousedown(dynamic arg0, dynamic arg1);

        [Js(Name = "mouseup")]
        public extern JQueryObject Mouseup(dynamic arg0, dynamic arg1);

        [Js(Name = "mousemove")]
        public extern JQueryObject Mousemove(dynamic arg0, dynamic arg1);

        [Js(Name = "mouseover")]
        public extern JQueryObject Mouseover(dynamic arg0, dynamic arg1);

        [Js(Name = "mouseout")]
        public extern JQueryObject Mouseout(dynamic arg0, dynamic arg1);

        [Js(Name = "mouseenter")]
        public extern JQueryObject Mouseenter(dynamic arg0, dynamic arg1);

        [Js(Name = "mouseleave")]
        public extern JQueryObject Mouseleave(dynamic arg0, dynamic arg1);

        [Js(Name = "change")]
        public extern JQueryObject Change(dynamic arg0, dynamic arg1);

        [Js(Name = "select")]
        public extern JQueryObject Select(dynamic arg0, dynamic arg1);

        [Js(Name = "submit")]
        public extern JQueryObject Submit(dynamic arg0, dynamic arg1);

        [Js(Name = "keydown")]
        public extern JQueryObject Keydown(dynamic arg0, dynamic arg1);

        [Js(Name = "keypress")]
        public extern JQueryObject Keypress(dynamic arg0, dynamic arg1);

        [Js(Name = "keyup")]
        public extern JQueryObject Keyup(dynamic arg0, dynamic arg1);

        [Js(Name = "error")]
        public extern JQueryObject Error(dynamic arg0, dynamic arg1);

        [Js(Name = "contextmenu")]
        public extern JQueryObject Contextmenu(dynamic arg0, dynamic arg1);

        [Js(Name = "hover")]
        public extern JQueryObject Hover(dynamic arg0, dynamic arg1);

        [Js(Name = "bind")]
        public extern JQueryObject Bind(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "unbind")]
        public extern JQueryObject Unbind(dynamic arg0, dynamic arg1);

        [Js(Name = "delegate")]
        public extern JQueryObject Delegate(dynamic arg0, dynamic arg1, dynamic arg2, dynamic arg3);

        [Js(Name = "undelegate")]
        public extern JQueryObject Undelegate(dynamic arg0, dynamic arg1, dynamic arg2);

        [Js(Name = "wrapAll")]
        public extern JQueryObject WrapAll(dynamic arg0);

        [Js(Name = "wrapInner")]
        public extern JQueryObject WrapInner(dynamic arg0);

        [Js(Name = "wrap")]
        public extern JQueryObject Wrap(dynamic arg0);

        [Js(Name = "unwrap")]
        public extern JQueryObject Unwrap();

        [Js(Name = "serialize")]
        public extern JQueryObject Serialize();

        [Js(Name = "serializeArray")]
        public extern JQueryObject SerializeArray();

        [Js(Name = "ajaxStart")]
        public extern JQueryObject AjaxStart(dynamic arg0);

        [Js(Name = "ajaxStop")]
        public extern JQueryObject AjaxStop(dynamic arg0);

        [Js(Name = "ajaxComplete")]
        public extern JQueryObject AjaxComplete(dynamic arg0);

        [Js(Name = "ajaxError")]
        public extern JQueryObject AjaxError(dynamic arg0);

        [Js(Name = "ajaxSuccess")]
        public extern JQueryObject AjaxSuccess(dynamic arg0);

        [Js(Name = "ajaxSend")]
        public extern JQueryObject AjaxSend(dynamic arg0);

        [Js(Name = "offset")]
        public extern JQueryObject Offset(dynamic arg0);

        [Js(Name = "position")]
        public extern JQueryObject Position();

        [Js(Name = "offsetParent")]
        public extern JQueryObject OffsetParent();

        [Js(Name = "scrollLeft")]
        public extern JQueryObject ScrollLeft(dynamic arg0);

        [Js(Name = "scrollTop")]
        public extern JQueryObject ScrollTop(dynamic arg0);

        [Js(Name = "innerHeight")]
        public extern JQueryObject InnerHeight(dynamic arg0, dynamic arg1);

        [Js(Name = "height")]
        public extern JQueryObject Height(dynamic arg0, dynamic arg1);

        [Js(Name = "outerHeight")]
        public extern JQueryObject OuterHeight(dynamic arg0, dynamic arg1);

        [Js(Name = "innerWidth")]
        public extern JQueryObject InnerWidth(dynamic arg0, dynamic arg1);

        [Js(Name = "width")]
        public extern JQueryObject Width(dynamic arg0, dynamic arg1);

        [Js(Name = "outerWidth")]
        public extern JQueryObject OuterWidth(dynamic arg0, dynamic arg1);

        [Js(Name = "size")]
        public extern JQueryObject Size();

        [Js(Name = "andSelf")]
        public extern JQueryObject AndSelf(dynamic arg0);

        extern IEnumerator<HTMLElement> IEnumerable<HTMLElement>.GetEnumerator();

        public extern IEnumerator GetEnumerator();
    }
}
