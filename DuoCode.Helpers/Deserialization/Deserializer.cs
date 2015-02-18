using System;

namespace DuoCode.Helpers
{
    public abstract class Deserializer<T> : IDeserializable<T>
    {
        protected abstract T GetObject();

        public abstract T Deserialize(string source);
    }
}