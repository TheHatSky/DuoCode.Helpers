using System;
using System.Diagnostics.CodeAnalysis;

using DuoCode.Runtime;

namespace Mindbox.PostAddress
{
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate")]
	public class SimpleSettlementAutocompleteViewModel
	{
		// BUG: "internal" modifier can not be used for constructor if another public ctor defined
		public SimpleSettlementAutocompleteViewModel()
		{
		}

		public SimpleSettlementAutocompleteViewModel(Settlement settlement, int? postIndex, Street street)
		{
			FillBySettlement(settlement);
			
			if (postIndex != null)
				PostIndex = postIndex.Value.ToString();

			if (street != null)
			{
				StreetName = street.Name;
				StreetTypeId = street.ObjectType.Id.ToString();
			}
		}

		[Js(Name = "postIndex")]
		public string PostIndex;

		[Js(Name = "regionName")]
		public string RegionName;

		[Js(Name = "districtName")]
		public string DistrictName;

		[Js(Name = "settlementId")]
		public string SettlementId;

		[Js(Name = "settlementName")]
		public string SettlementName;

		[Js(Name = "streetName")]
		public string StreetName;

		[Js(Name = "streetTypeId")]
		public string StreetTypeId;

		[Js(Name = "description")]
		public string Description;

		private void FillBySettlement(Settlement settlement)
		{
			if (settlement == null)
				throw new ArgumentNullException("settlement");

			SettlementId = settlement.Id.ToString();
			RegionName = settlement.Region != null ? settlement.Region.Name + " " + settlement.Region.ObjectType.FullName : null;
			DistrictName = settlement.District != null ? settlement.District.Name + " " + 
				settlement.District.ObjectType.FullName : "";
			SettlementName = settlement.Name;

			Description = settlement.ObjectType.FullName.ToLower();

			if (settlement.Region != null)
			{
				// специальный случай: если регион имеет тип "Город" (напр., Москва), то не добавляем его к описанию
				if (settlement.Region.ObjectType.FullName != PostAddress.CityObjectTypeFullName)
					Description += ", " + settlement.Region.Name + " " + settlement.Region.ObjectType.FullName.ToLower();
			}

			if (settlement.District != null)
			{
				Description += ", " + settlement.District.Name + " " + settlement.District.ObjectType.FullName.ToLower();
			}
		}
	}

	public class Street
	{
		public string Name { get; set; }
		public ObjectType ObjectType { get; set; }
	}

	public class Settlement
	{
		public int Id { get; set; }
		public Region Region { get; set; }
		public District District { get; set; }
		public string Name { get; set; }
		public ObjectType ObjectType { get; set; }
	}

	public class District
	{
		public string Name { get; set; }
		public ObjectType ObjectType { get; set; }
	}

	public class Region
	{
		public string Name { get; set; }
		public ObjectType ObjectType { get; set; }
	}

	public class ObjectType
	{
		public string FullName { get; set; }
		public int Id { get; set; }
	}
}
