namespace Mindbox.PostAddress.Tests
{
	[TestFixture(Timeout = 20000)]
	public sealed class Tests
	{
		[TestInitialize]
		public void TestInitialize()
		{
			PostAddress.ServerUrl = "https://mindbox.staging.directcrm.ru";
		}

		[Test]
		public void Autocomplete_PostIndex()
		{
			Assert.Expect(7);
			var done = Assert.GetAsyncFinalizer();

			var expectation = new SimpleSettlementAutocompleteViewModel
				{
					RegionName = "Москва Город",
					PostIndex = "115580",
					Description = "город",
					DistrictName = string.Empty,
					SettlementName = "Москва",
					SettlementId = "388707"
				};

			PostAddress.Autocomplete(
				"115580",
				searchResult =>
					{
						Assert.AreEqual(searchResult.Count, 1, "Должен прийти только один результат поиска автодополнения");

						var result = searchResult[0];

						Assert.AreEqual(result.RegionName, expectation.RegionName, "Город действительно Москва");
						Assert.AreEqual(result.PostIndex, expectation.PostIndex, "Почтовый адрес и впрямь 115580");
						Assert.AreEqual(result.Description, expectation.Description, "Описания совпадают");
						Assert.AreEqual(result.DistrictName, expectation.DistrictName, "Названия районов сопадают");
						Assert.AreEqual(result.SettlementId, expectation.SettlementId, "Id населенных пунктов совпадают");

						Assert.AreEqual(
							result.SettlementName,
							expectation.SettlementName,
							"Название населенных пунктов совпадают");

						done();
					}
				);
		}
	}
}