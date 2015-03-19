namespace Mindbox.PostAddress
{
	public static class Defaults
	{
		public const string ServerUrl = "https://mindbox-services.staging.directcrm.ru";

		public const string SimpleSettlementInputPanelId = "simple-settlement-input-panel";
		public const string SimpleSettlementInputTextboxId = "simple-settlement-input-textbox";
		public const string ComplexSettlementInputSwitchId = "complex-settlement-input-switch";

		public static AutocompleteDefaults Autocomplete { get; private set; }

		static Defaults()
		{
			Autocomplete = new AutocompleteDefaults();
		}
	}
}