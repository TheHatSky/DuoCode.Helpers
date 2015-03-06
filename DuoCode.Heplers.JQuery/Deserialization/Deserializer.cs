namespace DuoCode.JQuery
{
    public abstract class Deserializer<T>
    {
        protected abstract T GetObject();

        /// <summary>
        /// Throws <exception cref="DeserializationException"><see cref="DeserializationException"/></exception>.
        /// </summary>
        public abstract T Deserialize(string source);
    }
}