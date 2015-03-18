using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml.Linq;
using Itc.Commons;
using Itc.Commons.Model;
using Itc.DirectCrm.Model;

namespace Mindbox.PostAddress
{
	public class SettlementViewModel
	{
		public const string IdElementName = "id";
		public const string NameElementName = "name";
		public const string TypeElementName = "type";
		public const string FullNameElementName = "fullName";
		public const string ShortNameElementName = "shortName";
		public const string RegionElementName = "region";
		public const string DistrictElementName = "district";
		public const string SettlementElementName = "settlement";
		public const string IsRegionCenterElementName = "isRegionCenter";
		public const string IsDistrictCenterElementName = "isDistrictCenter";


		public string CountryId { get; set; }
		public string RegionId { get; set; }
		public string RegionName { get; private set; }
		public string RegionTypeId { get; private set; }
		public string RegionShortTypeName { get; private set; }
		public string RegionFullTypeName { get; private set; }
		public string DistrictId { get; set; }
		public string DistrictName { get; private set; }
		public string DistrictTypeId { get; private set; }
		public string DistrictShortTypeName { get; private set; }
		public string DistrictFullTypeName { get; private set; }
		public string SettlementId { get; set; }
		public string SettlementName { get; set; }
		public SettlementStatus? SettlementStatus { get; private set; }
		public string SettlementTypeId { get; set; }
		public string SettlementShortTypeName { get; private set; }
		public string SettlementFullTypeName { get; private set; }

		public int? CountryIdValue
		{
			get
			{
				int? countryIdIdValue;
				if (!PostAddressController.TryParseIdOrSeparator(CountryId, out countryIdIdValue))
				{
					throw new InvalidClientRequestException("Некорректный CountryId.");
				}
				return countryIdIdValue;
			}
		}

		public int? SettlementIdValue
		{
			get
			{
				int? settlementIdValue;

				if (!PostAddressController.TryParseIdOrSeparator(SettlementId, out settlementIdValue))
					throw new InvalidClientRequestException("Некорректный SettlementId.");

				return settlementIdValue;
			}
		}

		public int? SettlementTypeIdValue
		{
			get
			{
				int? settlementTypeId;

				if (!PostAddressController.TryParseIdOrSeparator(SettlementTypeId, out settlementTypeId))
					throw new InvalidClientRequestException("Некорректный SettlementTypeId.");

				return settlementTypeId;
			}
		}


		public void BindSettlement(ModelContext modelContext, Settlement settlement)
		{
			if (modelContext == null)
				throw new ArgumentNullException("modelContext");
			if (settlement == null)
				throw new ArgumentNullException("settlement");

			Clear();

			RegionId = settlement.RegionId.ToString(CultureInfo.InvariantCulture);
			RegionName = settlement.Region.Name;
			RegionTypeId = settlement.Region.ObjectType.Id.ToString(CultureInfo.InvariantCulture);
			RegionShortTypeName = settlement.Region.ObjectType.ShortName;
			RegionFullTypeName = settlement.Region.ObjectType.FullName;

			if (settlement.District != null)
			{
				DistrictId = settlement.District.Id.ToString(CultureInfo.InvariantCulture);
				DistrictName = settlement.District.Name;
				DistrictTypeId = settlement.District.ObjectType.Id.ToString(CultureInfo.InvariantCulture);
				DistrictShortTypeName = settlement.District.ObjectType.ShortName;
				DistrictFullTypeName = settlement.District.ObjectType.FullName;
			}

			SettlementId = settlement.Id.ToString(CultureInfo.InvariantCulture);
			SettlementName = settlement.Name;
			SettlementStatus = settlement.Status;
			SettlementTypeId = settlement.ObjectType.Id.ToString(CultureInfo.InvariantCulture);
			SettlementShortTypeName = settlement.ObjectType.ShortName;
			SettlementFullTypeName = settlement.ObjectType.FullName;
		}

		public void Clear()
		{
			RegionId = null;
			RegionName = null;
			RegionTypeId = null;
			RegionShortTypeName = null;
			RegionFullTypeName = null;
			DistrictId = null;
			DistrictName = null;
			DistrictTypeId = null;
			DistrictShortTypeName = null;
			DistrictFullTypeName = null;
			SettlementId = null;
			SettlementName = null;
			SettlementStatus = null;
			SettlementTypeId = null;
			SettlementShortTypeName = null;
			SettlementFullTypeName = null;
		}

		public IEnumerable<XElement> ToXml(bool withObjectIds = true, bool withRegionAndDistrict = true)
		{
			var result = new List<XElement>();

			if (withRegionAndDistrict)
			{
				var regionElement = new XElement(RegionElementName);

				if (withObjectIds)
					regionElement.Add(new XElement(IdElementName, RegionId));

				if (!string.IsNullOrEmpty(RegionName))
					regionElement.Add(new XElement(NameElementName, RegionName));

				if (!string.IsNullOrEmpty(RegionTypeId))
					regionElement.Add(
						CreateObjectTypeElement(RegionTypeId, RegionFullTypeName, RegionShortTypeName, withObjectIds));

				result.Add(regionElement);

				if (!string.IsNullOrWhiteSpace(DistrictId))
				{
					var districtElement = new XElement(DistrictElementName);

					if (withObjectIds)
						districtElement.Add(new XElement(IdElementName, DistrictId));

					if (!string.IsNullOrEmpty(DistrictName))
						districtElement.Add(new XElement(NameElementName, DistrictName));

					if (!string.IsNullOrEmpty(DistrictTypeId))
						districtElement.Add(
							CreateObjectTypeElement(DistrictTypeId, DistrictFullTypeName, DistrictShortTypeName, withObjectIds));

					result.Add(districtElement);
				}
			}

			var settlementElement = new XElement(SettlementElementName);

			if (withObjectIds)
				settlementElement.Add(new XElement(IdElementName, SettlementId));

			settlementElement.Add(new XElement(NameElementName, SettlementName));

			if (SettlementStatus.HasValue)
			{
				if (SettlementStatus.Value == Model.SettlementStatus.RegionCenter ||
						SettlementStatus.Value == Model.SettlementStatus.RegionAndDistrictCenter)
					settlementElement.Add(new XElement(IsRegionCenterElementName));
				if (SettlementStatus.Value == Model.SettlementStatus.DistrictCenter ||
						SettlementStatus.Value == Model.SettlementStatus.RegionAndDistrictCenter)
					settlementElement.Add(new XElement(IsDistrictCenterElementName));
			}

			if (!string.IsNullOrWhiteSpace(SettlementTypeId))
				settlementElement.Add(
					CreateObjectTypeElement(
						SettlementTypeId,
						SettlementFullTypeName,
						SettlementShortTypeName,
						withObjectIds));

			result.Add(settlementElement);

			return new ReadOnlyCollection<XElement>(result);
		}


		private XElement CreateObjectTypeElement(
			string typeId,
			string fullTypeName,
			string shortTypeName,
			bool withObjectIds = true)
		{
			var typeElement = new XElement(TypeElementName);

			if (withObjectIds)
				typeElement.Add(new XElement(IdElementName, typeId));

			if (!string.IsNullOrEmpty(fullTypeName))
				typeElement.Add(new XElement(FullNameElementName, fullTypeName));

			if (!string.IsNullOrEmpty(shortTypeName))
				typeElement.Add(new XElement(ShortNameElementName, shortTypeName));
			return typeElement;
		}

		public void FromXml(XElement xml)
		{
			Clear();

			if (xml == null)
				return;

			var regionElement = xml.Element(RegionElementName);

			if (regionElement != null)
			{
				RegionId = regionElement.GetChild(IdElementName).GetStringValue();
				RegionName = regionElement.GetChild(NameElementName).GetStringValue();
				RegionTypeId = regionElement.GetChild(TypeElementName).GetChild(IdElementName).GetStringValue();
				RegionShortTypeName = regionElement.GetChild(TypeElementName).GetChild(ShortNameElementName).GetStringValue();
				RegionFullTypeName = regionElement.GetChild(TypeElementName).GetChild(FullNameElementName).GetStringValue();
			}

			var districtElement = xml.Element(DistrictElementName);

			if (districtElement != null)
			{
				DistrictId = districtElement.GetChild(IdElementName).GetStringValue();
				DistrictName = districtElement.GetChild(NameElementName).GetStringValue();
				DistrictTypeId = districtElement.GetChild(TypeElementName).GetChild(IdElementName).GetStringValue();
				DistrictShortTypeName =
					districtElement.GetChild(TypeElementName).GetChild(ShortNameElementName).GetStringValue();
				DistrictFullTypeName =
					districtElement.GetChild(TypeElementName).GetChild(FullNameElementName).GetStringValue();
			}

			var settlementElement = xml.Element(SettlementElementName);

			if (settlementElement != null)
			{
				SettlementId = settlementElement.GetChild(IdElementName).GetStringValue();
				SettlementName = settlementElement.GetChild(NameElementName).GetStringValue();
				SettlementTypeId = settlementElement.GetChild(TypeElementName).GetChild(IdElementName).GetStringValue();
				SettlementShortTypeName =
					settlementElement.GetChild(TypeElementName).GetChild(ShortNameElementName).GetStringValue();
				SettlementFullTypeName =
					settlementElement.GetChild(TypeElementName).GetChild(FullNameElementName).GetStringValue();

				var isRegionCenterElement = settlementElement.GetChild(IsRegionCenterElementName);
				var isDistrictCenterElement = settlementElement.GetChild(IsDistrictCenterElementName);

				if (isRegionCenterElement != null && isDistrictCenterElement != null)
					SettlementStatus = Model.SettlementStatus.RegionAndDistrictCenter;
				else if (isRegionCenterElement != null)
					SettlementStatus = Model.SettlementStatus.RegionCenter;
				else if (isDistrictCenterElement != null)
					SettlementStatus = Model.SettlementStatus.DistrictCenter;
				else
					SettlementStatus = Model.SettlementStatus.None;
			}
		}
	}
}