using DuoCode.Dom;
using DuoCode.Runtime;

namespace DuoCode.JQuery
{
    // This provides typeof(Md5HashInfo).GetProperties() to be implemented in compiled js.
    [Js(ReflectionLevel = ReflectionLevel.Partial)]
    public class Md5HashInfo
    {
        [JsonName("md5")]
        public string Md5Hash { get; set; }

        [JsonName("original")]
        public string Text { get; set; }

        public void Foo()
        {
            Global.console.log(string.Format("text: {0}\nmd5: {1}", Text, Md5Hash));
        }
    }
}