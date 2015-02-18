using System;

namespace DuoCode.Helpers
{
    public class JsonNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public JsonNameAttribute(string name)
        {
            Name = name;
        }
    }
}
