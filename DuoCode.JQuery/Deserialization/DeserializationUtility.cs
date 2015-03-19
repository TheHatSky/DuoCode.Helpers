namespace DuoCode.JQuery
{
	public class DeserializationUtility
	{
		/// <summary>
		/// Throws <exception cref="DeserializationException"><see cref="DeserializationException"/></exception>.
		/// </summary>
		public static TResponse Deserialize<TResponse, TDeserializer>(string source)
			where TDeserializer : Deserializer<TResponse>, new()
		{
			var deserializer = new TDeserializer();

			return deserializer.Deserialize(source);
		}
	}
}