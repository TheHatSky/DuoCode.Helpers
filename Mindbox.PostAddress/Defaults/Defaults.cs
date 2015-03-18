namespace Mindbox.PostAddress
{
	public static class Defaults
	{
		public static AutocompleteDefaults Autocomplete { get; private set; }

		static Defaults()
		{
			Autocomplete = new AutocompleteDefaults();
		}
	}
}