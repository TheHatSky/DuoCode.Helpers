using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using DuoCode.Dom;
using DuoCode.Helpers;
using DuoCode.JQuery;
using DuoCode.Runtime;

namespace Mindbox.PostAddress
{
	public static class PostAddress
	{
		public const string JsonpCallbackParameterName = "jsonpCallback";

		public const string UserDefinedObjectTypeFullName = "Пользовательский";
		public const string CityObjectTypeFullName = "Город";
		public const string StreetObjectTypeFullName = "Улица";

		public static string ServerUrl { get; set; }

		internal static bool Debug { get; private set; }

		#region Simple Settlement

		#region SimpleSettlementInputPanel

		public static string SimpleSettlementInputPanelId { get; set; }

		private static HTMLElement simpleSettlementInputPanel;

		public static HTMLElement SimpleSettlementInputPanel
		{
			get
			{
				if (simpleSettlementInputPanel == null)
					simpleSettlementInputPanel = Global.document.getElementById(SimpleSettlementInputPanelId);

				if (simpleSettlementInputPanel == null)
					throw new ElementNotFoundException("Не найден SimpleSettlementInputPanel");

				return simpleSettlementInputPanel;
			}
		}

		#endregion

		#region SimpleSettlementInputTextbox

		public static string SimpleSettlementInputTextboxId { get; set; }

		private static HTMLInputElement simpleSettlementInputTextbox;

		public static HTMLInputElement SimpleSettlementInputTextbox
		{
			get
			{
				if (simpleSettlementInputTextbox == null)
					simpleSettlementInputTextbox = Global.document.getElementById(SimpleSettlementInputTextboxId)
						.As<HTMLInputElement>();

				if (simpleSettlementInputTextbox == null)
					throw new ElementNotFoundException("Не найден SimpleSettlementInputTextbox");

				return simpleSettlementInputTextbox;
			}
		}

		#endregion

		#region ComplexSettlementInputSwitch

		public static string ComplexSettlementInputSwitchId { get; set; }

		private static HTMLElement complexSettlementInputSwitch;

		public static HTMLElement ComplexSettlementInputSwitch
		{
			get
			{
				if (complexSettlementInputSwitch == null)
					complexSettlementInputSwitch = Global.document.getElementById(ComplexSettlementInputSwitchId);

				if (complexSettlementInputSwitch == null)
					throw new ElementNotFoundException("Не найден ComplexSettlementInputSwitch");

				return complexSettlementInputSwitch;
			}
		}

		#endregion

		#endregion

		static PostAddress()
		{
			ServerUrl = Defaults.ServerUrl;

			SimpleSettlementInputPanelId = Defaults.SimpleSettlementInputPanelId;
			SimpleSettlementInputTextboxId = Defaults.SimpleSettlementInputTextboxId;
			ComplexSettlementInputSwitchId = Defaults.ComplexSettlementInputSwitchId;
		}

		public static string GetSettlementById()
		{
			return "asdasfa";
		}

		// For select2
		public static void Autocomplete(dynamic query)
		{
			Autocomplete(
				AsExtension.As<string>(query.term),
				(Action<JsArray<SimpleSettlementAutocompleteViewModel>>)(data =>
					{
						var resultData = new JsObject();
						resultData["results"] = data.map<JsObject>(
							((Func<SimpleSettlementAutocompleteViewModel, JsObject>)(val =>
								{
									var item = new JsObject();
									item["id"] = query.term;
									item["text"] = string.Format("{0}: {1} - {2} - {3}",
														val.PostIndex,
														val.RegionName,
														val.DistrictName,
														val.SettlementName);

									return item;
								})).As<JsFunction>());

						query.callback(resultData);
					})
			);
		}

		public static void Autocomplete(
			string search,
			Action<JsArray<SimpleSettlementAutocompleteViewModel>> callback)
		{
			Log("Начат запрос автокомплита для значения '{0}'", search);

			var options = new JsonAjaxSettings<JsArray<SimpleSettlementAutocompleteViewModel>>
			{
				IsCrossDomain = true,
				Url = string.Format(
					"{0}/v1/postaddress/autocomplete/simplesettlements/for-country/1?searchValue={1}",
					ServerUrl,
					search),
				JsonpCallbackParameterName = JsonpCallbackParameterName,
				DataType = AjaxDataType.jsonp,
				Method = Method.GET,
				OnSuccess = (data, status, jqXhr) =>
					{
						Log("Автокомплит для значения '{0}' ({1} шт.) успешно получен", search, data.length);

						if (callback != null)
							callback(data);
						else
							Defaults.Autocomplete.OnSuccess(data.ToList());
					}
			};

			JQuery.Ajax(options);
		}

		#region Log

		internal static void Log(dynamic thing)
		{
			if (!Debug)
				return;

			Global.console.log(string.Format("[{0}]", DateTime.Now.ToLogString()));
			Global.console.log(thing);
		}

		internal static void Log(string format, params object[] values)
		{
			if (!Debug)
				return;

			Global.console.log(
				string.Format(
					"[{0}] {1}",
					DateTime.Now.ToLogString(),
					string.Format(format, values)));
		}

		#endregion

		public static void Initialize(dynamic options = null)
		{
			Initialize(new PostAddressOptions(options));
		}

		internal static void Initialize(PostAddressOptions options = null)
		{
			if (options == null)
				options = new PostAddressOptions();

			Debug = options.Debug;
			Log("Включен режим отладки");

			SimpleSettlementInputTextbox.onchange = e =>
				{
					var input = e.target.As<HTMLInputElement>();
					Log("SimpleSettlementInputTextbox изменен на '{0}'", input.value);
					Autocomplete(input.value, options.OnAutocompleteSuccess);
					return true;
				};
		}
	}
}
