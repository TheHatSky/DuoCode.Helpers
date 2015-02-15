namespace DuoCode.Helpers
{
    public interface IDeserializable<out T>
    {
        /// <exception cref="DeserializationException">In case source can not be deserialized properly.</exception>
        T Deserialize(string source);
    }
}
