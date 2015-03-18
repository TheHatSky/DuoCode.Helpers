using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itc.Commons.Model;
using Itc.DirectCrm.Model;

namespace Mindbox.PostAddress
{

	public class PostAddressDictionariesViewModel
	{

		public PostAddressDictionariesViewModel()
		{
			Countries = new List<PostAddressCountryViewModel>();
			Regions = new List<PostAddressPartViewModel>();
			Districts = new List<PostAddressPartViewModel>();
			Settlements = new List<PostAddressPartViewModel>();
			SettlementTypes = new List<PostAddressPartTypeViewModel>();
			StreetTypes = new List<PostAddressPartTypeViewModel>();
			SelectedRegionId = PostAddressController.EmptyValue;
			SelectedDistrictId = PostAddressController.EmptyValue;
			SelectedSettlementId = PostAddressController.EmptyValue;
			SelectedSettlementTypeId = PostAddressController.EmptyValue;
		}

		public IList<PostAddressCountryViewModel> Countries { get; private set; }
		public IList<PostAddressPartViewModel> Regions { get; private set; }
		public IList<PostAddressPartViewModel> Districts { get; private set; }
		public IList<PostAddressPartViewModel> Settlements { get; private set; }
		public IList<PostAddressPartTypeViewModel> SettlementTypes { get; private set; }
		public IList<PostAddressPartTypeViewModel> StreetTypes { get; private set; }
		public string SelectedPostIndex { get; private set; }
		public PostAddressCountryViewModel SelectedCountry { get; private set; }
		public string SelectedRegionId { get; private set; }
		public string SelectedRegionName { get; private set; }
		public string SelectedDistrictId { get; private set; }
		public string SelectedDistrictName { get; private set; }
		public string SelectedSettlementId { get; private set; }
		public string SelectedSettlementName { get; private set; }
		public string SelectedSettlementType { get; private set; }
		public string SelectedSettlementTypeId { get; private set; }

		public void SetSelectedCountry(Country country)
		{
			SelectedCountry = new PostAddressCountryViewModel(country);
		}

		public void SetSelectedRegion(Region region)
		{
			SetSelectedRegionId(region == null ? default(int?) : region.Id);
			if (region != null && region.ObjectType.FullName != ObjectTypeRepository.CityObjectTypeFullName)
			{
				SelectedRegionName = region.Name + " " + region.ObjectType.FullName.ToLower();
			}
		}

		public void SetSelectedRegionId(int? regionId)
		{
			SelectedRegionId = regionId == null ?
				PostAddressController.EmptyValue :
				regionId.Value.ToString(CultureInfo.InvariantCulture);
		}

		public void SetSelectedDistrict(District district)
		{
			SetSelectedDistrictId(district == null ? default(int?) : district.Id);
			SelectedDistrictName = district != null ? district.Name + " " + district.ObjectType.FullName.ToLower() : null;
		}

		public void SetSelectedDistrictId(int? districtId)
		{
			SelectedDistrictId = districtId == null ?
				PostAddressController.EmptyValue :
				districtId.Value.ToString(CultureInfo.InvariantCulture);
		}

		public void SetSelectedSettlement(Settlement settlement)
		{
			SetSelectedSettlementId(settlement == null ? default(int?) : settlement.Id);
			SelectedSettlementName = settlement != null ? settlement.Name : null;

			SetSelectedSettlementTypeId(settlement == null ? default(int?) : settlement.ObjectType.Id);
			SelectedSettlementType = settlement != null ? settlement.ObjectType.FullName.ToLower() : null;
		}
		
		public void SetSelectedSettlementId(int? settlementId)
		{
			SelectedSettlementId = settlementId == null ?
				PostAddressController.EmptyValue :
				settlementId.Value.ToString(CultureInfo.InvariantCulture);
		}

		public void SetSelectedSettlementTypeId(int? settlementTypeId)
		{
			SelectedSettlementTypeId = settlementTypeId == null ?
				PostAddressController.EmptyValue :
				settlementTypeId.Value.ToString(CultureInfo.InvariantCulture);
		}

		public virtual Dictionary<string, object> ToJson()
		{
			var result = new Dictionary<string, object>
			{ 
				{ "countries", Countries.Select(region => region.ToJson()).ToList() },
				{ "regions", Regions.Select(region => region.ToJson()).ToList() },
				{ "districts", Districts.Select(district => district.ToJson()).ToList() },
				{ "settlements", Settlements.Select(settlement => settlement.ToJson()).ToList() },
				{ "settlementTypes", SettlementTypes.Select(settlementType => settlementType.ToJson()).ToList() },
				{ "streetTypes", StreetTypes.Select(streetType => streetType.ToJson()).ToList() },
				{ "selectedCountry", SelectedCountry.ToJson() },
				{ "selectedRegion", SelectedRegionId },
				{ "selectedDistrict", SelectedDistrictId },
				{ "selectedDistrictName", SelectedDistrictName },
				{ "selectedSettlement", SelectedSettlementId },
				{ "selectedSettlementName", SelectedSettlementName },
				{ "selectedSettlementType", SelectedSettlementType },
				{ "selectedSettlementTypeId", SelectedSettlementTypeId },
			};

			if (SelectedRegionName != SelectedSettlementName)
			{
				result.Add("selectedRegionName", SelectedRegionName);
			}

			if (SelectedPostIndex != null)
			{
				result.Add("selectedPostIndex", SelectedPostIndex);
			}

			return result;
		}

		public void SetSelectedPostIndex(int postIndex)
		{
			SelectedPostIndex = postIndex.ToString();
		}
	}

}
