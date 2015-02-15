using System;

namespace DuoCode.Helpers
{
    public abstract class Deserializer<T> : IDeserializable<T>
    {
        public abstract T GetObject();

        public abstract T Deserialize(string source);
    }
}