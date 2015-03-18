using System;
using System.Collections.Generic;
using System.Linq;

using DuoCode.Dom;
using DuoCode.Helpers;
using DuoCode.JQuery;
using DuoCode.Runtime;

namespace Mindbox.PostAddress
{
	public static class PostAddress
	{
		public const string UserDefinedObjectTypeFullName = "Пользовательский";
		public const string CityObjectTypeFullName = "Город";
		public const string StreetObjectTypeFullName = "Улица";

		// https://mindbox.staging.directcrm.ru/v1/postaddress/autocomplete/simplesettlements/for-country/1?searchValue=115580

		public static string ServerUrl { get; set; }

		public static string GetSettlementById()
		{
			DebugPrint();

			return "asdasfa";
		}

		public static void Autocomplete(
			string search,
			Action<List<SimpleSettlementAutocompleteViewModel>> callback = null)
		{
			var options = new JsonAjaxSettings<JsArray<SimpleSettlementAutocompleteViewModel>>
			{
				IsCrossDomain = true,
				Url = string.Format(
					"{0}/v1/postaddress/autocomplete/simplesettlements/for-country/1?searchValue={1}",
					ServerUrl,
					search),
				JsonpCallbackParameterName = "jsonpCallback",
				DataType = AjaxDataType.jsonp,
				Method = Method.GET,
				OnSuccess = (data, status, jqXhr) =>
					{
						var listResult = data.ToList();

						if (callback != null)
							callback(listResult);

						else Defaults.Autocomplete.OnSuccess(listResult, status, jqXhr);
					}
			};

			JQuery.Ajax(options);
		}

		private static void DebugPrint()
		{
			Global.console.log(string.Format("Url: {0}", ServerUrl));
		}

		static PostAddress()
		{
			ServerUrl = "https://mindbox-services.staging.directcrm.ru";
		}
	}
}
