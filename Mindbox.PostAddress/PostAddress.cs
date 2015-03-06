using DuoCode.Dom;

namespace Mindbox.PostAddress
{
	public static class PostAddress
	{
		private static string ServerUrl { get; set; }

		public static string GetSettlementById()
		{
			DebugPrint();

			return "asdasfa";
		}

		private static void DebugPrint()
		{
			Global.console.log(string.Format("Url: {0}", ServerUrl));
		}

		static PostAddress()
		{
			ServerUrl = "assdagwefwq";
		}
	}
}
