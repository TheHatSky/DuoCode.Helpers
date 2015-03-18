using System;
using System.Globalization;
using System.Xml.Linq;
using Itc.Commons;
using Itc.Commons.Model;
using Itc.Commons.Web;
using Itc.DirectCrm.Model;

namespace Mindbox.PostAddress
{
	public class PostAddressViewModel
	{
		public const string PostAddressElementName = "postAddress";
		public const string IdElementName = "id";
		public const string NameElementName = "name";
		public const string TypeElementName = "type";
		public const string FullNameElementName = "fullName";
		public const string ShortNameElementName = "shortName";
		public const string PostIndexElementName = "postIndex";
		public const string RegionElementName = "region";
		public const string DistrictElementName = "district";
		public const string SettlementElementName = "settlement";
		public const string StreetElementName = "street";
		public const string HouseElementName = "house";
		public const string EstateElementName = "estate";
		public const string BuildingElementName = "building";
		public const string UnitElementName = "unit";
		public const string FlatElementName = "flat";
		public const string OfficeElementName = "office";
		public const string CommentsElementName = "comments";
		public const string Line1ElementName = "line1";
		public const string Line2ElementName = "line2";


		public PostAddressViewModel()
		{
			Settlement = new SettlementViewModel();
		}


		public int? Id { get; set; }
		public string PostIndex { get; set; }
		public SettlementViewModel Settlement { get; private set; }
		public string StreetId { get; private set; }
		public string StreetName { get; set; }
		public string StreetTypeId { get; set; }
		public string StreetTypeShortName { get; private set; }
		public string StreetTypeFullName { get; private set; }
		public bool IsEstate { get; set; }
		public string House { get; set; }
		public string Building { get; set; }
		public string Unit { get; set; }
		public bool IsOffice { get; set; }
		public string Flat { get; set; }
		public string Comments { get; set; }
		public string Line1 { get; set; }
		public string Line2 { get; set; }


		public void BindPostAddress(ModelContext modelContext, Location location)
		{
			if (modelContext == null)
				throw new ArgumentNullException("modelContext");
			if (location == null)
				throw new ArgumentNullException("location");

			Clear();

			Id = location.Id;

			PostIndex = location.PostIndex != null ? location.PostIndex.Value.ToString() : null;

			Settlement.BindSettlement(modelContext, location.Settlement);

			var structuredPostAddress = location as StructuredPostAddress;
			var unstructuredPostAddress = location as UnstructuredPostAddress;
			if (structuredPostAddress != null)
			{
				if (structuredPostAddress.Street != null)
				{
					StreetId = structuredPostAddress.Street.Id.ToString(CultureInfo.InvariantCulture);
					StreetName = structuredPostAddress.Street.Name;
					StreetTypeId = structuredPostAddress.Street.ObjectType.Id.ToString(CultureInfo.InvariantCulture);
					StreetTypeShortName = structuredPostAddress.Street.ObjectType.ShortName;
					StreetTypeFullName = structuredPostAddress.Street.ObjectType.FullName;
				}

				IsEstate = structuredPostAddress.IsEstate.HasValue && structuredPostAddress.IsEstate.Value;
				House = structuredPostAddress.House;
				Building = structuredPostAddress.Building;
				Unit = structuredPostAddress.Unit;
				IsOffice = structuredPostAddress.IsOffice.HasValue && structuredPostAddress.IsOffice.Value;
				Flat = structuredPostAddress.Flat;
				Comments = structuredPostAddress.Comments;
			}
			if (unstructuredPostAddress != null)
			{
				Line1 = unstructuredPostAddress.Line1;
				Line2 = unstructuredPostAddress.Line2;
			}
		}

		public void Clear()
		{
			Id = null;
			PostIndex = null;
			Settlement.Clear();
			StreetId = null;
			StreetName = null;
			StreetTypeId = null;
			StreetTypeShortName = null;
			StreetTypeFullName = null;
			IsEstate = false;
			House = null;
			Building = null;
			Unit = null;
			IsOffice = false;
			Flat = null;
			Comments = null;
			Line1 = null;
			Line2 = null;
		}

		public void FromXml(XElement xml)
		{
			Clear();

			if (xml == null)
				return;

			PostIndex = xml.GetChild(PostIndexElementName).GetStringValue();

			Settlement.FromXml(xml);

			var streetElement = xml.Element(StreetElementName);

			if (streetElement != null)
			{
				StreetId = streetElement.GetChild(IdElementName).GetStringValue();
				StreetName = streetElement.GetChild(NameElementName).GetStringValue();
				StreetTypeId = streetElement.GetChild(TypeElementName).GetChild(IdElementName).GetStringValue();
				StreetTypeShortName = streetElement.GetChild(TypeElementName).GetChild(ShortNameElementName).GetStringValue();
				StreetTypeFullName = streetElement.GetChild(TypeElementName).GetChild(FullNameElementName).GetStringValue();
			}

			var house = xml.GetChild(HouseElementName).GetStringValue();
			var estate = xml.GetChild(EstateElementName).GetStringValue();

			if (house != null)
			{
				House = house;
				IsEstate = false;
			}
			else if (estate != null)
			{
				House = estate;
				IsEstate = true;
			}

			Building = xml.GetChild(BuildingElementName).GetStringValue();

			Unit = xml.GetChild(UnitElementName).GetStringValue();

			var flat = xml.GetChild(FlatElementName).GetStringValue();
			var office = xml.GetChild(OfficeElementName).GetStringValue();

			if (flat != null)
			{
				Flat = flat;
				IsOffice = false;
			}
			else if (office != null)
			{
				Flat = office;
				IsOffice = true;
			}

			Comments = xml.GetChild(CommentsElementName).GetStringValue();
		}

		public XElement ToXml(bool withObjectIds = true)
		{
			var result = new XElement(PostAddressElementName);

			if (!string.IsNullOrEmpty(PostIndex))
				result.Add(new XElement(PostIndexElementName, PostIndex));

			AddSettlementElement(result, withObjectIds);

			AddStreetElement(result, withObjectIds);

			AddOtherElements(result);

			return result;
		}

		public Location TryCreateOrSaveNewLocation(
			StructuredPostAddress newStructuredPostAddress,
			UnstructuredPostAddress newUnstructuredPostAddress,
			ValidationKey postIndexValidationKey,
			Settlement newSettlement,
			Street newStreet,
			MvcModelContext mvcContext,
			ISubmodelInputRegistrator<PostAddressViewModel> inputRegistrator,
			bool isPostAddressRequired,
			bool isSettlementRequired)
		{
			if (newStructuredPostAddress == null)
				throw new ArgumentNullException("newStructuredPostAddress");
			if (newUnstructuredPostAddress == null)
				throw new ArgumentNullException("newUnstructuredPostAddress");
			if (postIndexValidationKey == null)
				throw new ArgumentNullException("postIndexValidationKey");
			if (newSettlement == null)
				throw new ArgumentNullException("newSettlement");
			if (newStreet == null)
				throw new ArgumentNullException("newStreet");
			if (mvcContext == null)
				throw new ArgumentNullException("mvcContext");
			if (inputRegistrator == null)
				throw new ArgumentNullException("inputRegistrator");

			inputRegistrator.RegisterEndUserInput(
				postIndexValidationKey,
				model => model.PostIndex,
				externalLocationName: PostIndexElementName);
			inputRegistrator.RegisterEndUserInput(
				newSettlement,
				settlement => settlement.Region,
				model => model.Settlement.RegionId,
				externalLocationName: RegionElementName);
			inputRegistrator.RegisterEndUserInput(
				newSettlement,
				settlement => settlement.District,
				model => model.Settlement.DistrictId,
				externalLocationName: DistrictElementName);
			inputRegistrator.RegisterEndUserInput(
				newSettlement,
				settlement => settlement.Id,
				model => model.Settlement.SettlementId,
				externalLocationName: SettlementElementName);
			inputRegistrator.RegisterEndUserInput(
				newSettlement,
				settlement => settlement.Name,
				model => model.Settlement.SettlementName,
				externalLocationName: SettlementElementName);
			inputRegistrator.RegisterEndUserInput(
				newSettlement,
				settlement => settlement.ObjectType,
				model => model.Settlement.SettlementTypeId,
				externalLocationName: SettlementElementName);

			inputRegistrator.RegisterEndUserInput(
				newStructuredPostAddress,
				postAddress => postAddress.House,
				StructuredPostAddress.HouseValidationPartName,
				model => model.House,
				externalLocationName: HouseElementName);
			inputRegistrator.RegisterEndUserInput(
				newStructuredPostAddress,
				postAddress => postAddress.House,
				StructuredPostAddress.EstateValidationPartName,
				model => model.House,
				externalLocationName: HouseElementName);
			inputRegistrator.RegisterEndUserInput(
				newStructuredPostAddress,
				postAddress => postAddress.Building,
				model => model.Building,
				externalLocationName: BuildingElementName);
			inputRegistrator.RegisterEndUserInput(
				newStructuredPostAddress,
				postAddress => postAddress.Unit,
				model => model.Unit,
				externalLocationName: UnitElementName);
			inputRegistrator.RegisterEndUserInput(
				newStructuredPostAddress,
				postAddress => postAddress.Flat,
				StructuredPostAddress.FlatValidationPartName,
				model => model.Flat,
				externalLocationName: FlatElementName);
			inputRegistrator.RegisterEndUserInput(
				newStructuredPostAddress,
				postAddress => postAddress.Flat,
				StructuredPostAddress.OfficeValidationPartName,
				model => model.Flat,
				externalLocationName: FlatElementName);
			inputRegistrator.RegisterEndUserInput(
				newStructuredPostAddress,
				postAddress => postAddress.Comments,
				model => model.Comments,
				externalLocationName: CommentsElementName);
			inputRegistrator.RegisterEndUserInput(
				newUnstructuredPostAddress,
				postAddress => postAddress.Line1,
				model => model.Line1,
				externalLocationName: Line1ElementName);
			inputRegistrator.RegisterEndUserInput(
				newUnstructuredPostAddress,
				postAddress => postAddress.Line2,
				model => model.Line2,
				externalLocationName: Line2ElementName);

			var country = mvcContext
				.ModelContext
				.Repositories
				.Get<CountryRepository>()
				.GetByIdFromClientOrSingleAllowed(Settlement.CountryIdValue);

			Location location;
			if (country.IsAddressStructured)
			{
				var builder = new StructuredPostAddressBuilder
				{
					StreetId = PostAddressController.TryParseIdOrSeparatorFromClient(
						StreetId,
						"Некорректный идентификатор улицы."),
					House = IsEstate ? null : House,
					Estate = IsEstate ? House : null,
					Building = Building,
					Unit = Unit,
					Flat = IsOffice ? null : Flat,
					Office = IsEstate ? Flat : null,
					Comments = Comments,
					NewSettlement = newSettlement,
					SettlementPostIndexOrNameValidationKey = ValidationKey.Unique(),
					NewStreet = newStreet
				};
				FillLocationFields(builder);

				if (builder.StreetId == null)
				{
					inputRegistrator.RegisterEndUserInput(
						newStreet,
						street => street.Name,
						model => model.StreetName,
						externalLocationName: StreetElementName);
					builder.StreetName = StreetName;

					inputRegistrator.RegisterEndUserInput(
						newStreet,
						street => street.ObjectType,
						model => model.StreetTypeId,
						externalLocationName: StreetElementName);
					builder.StreetTypeId = PostAddressController.TryParseIdOrSeparatorFromClient(
						StreetTypeId,
						"Некорректный идентификатор типа улицы.");
				}
				else
				{
					// TODO: Почему IdElementName???
					inputRegistrator.RegisterEndUserInput(
						newStructuredPostAddress,
						postAdddress => postAdddress.Street,
						model => model.StreetId,
						externalLocationName: IdElementName);
				}

				location = builder.TryCreateOrSaveNewLocation(
					newStructuredPostAddress,
					postIndexValidationKey,
					mvcContext.ModelContext,
					isPostAddressRequired,
					isSettlementRequired);
			}
			else
			{
				var builder = new UnstructuredPostAddressBuilder
				{
					Line1 = Line1,
					Line2 = Line2,
					NewSettlement = newSettlement,
					SettlementPostIndexOrNameValidationKey = ValidationKey.Unique()
				};
				FillLocationFields(builder);

				location = builder.TryCreateOrSaveNewLocation(
					newUnstructuredPostAddress,
					postIndexValidationKey,
					mvcContext.ModelContext,
					isPostAddressRequired,
					isSettlementRequired);
			}

			mvcContext.ValidationContext.Validate(location);
			return location;
		}


		private void AddOtherElements(XElement result)
		{
			if (!string.IsNullOrWhiteSpace(House))
				result.Add(new XElement(IsEstate ? EstateElementName : HouseElementName, House));

			if (!string.IsNullOrWhiteSpace(Building))
				result.Add(new XElement(BuildingElementName, Building));

			if (!string.IsNullOrWhiteSpace(Unit))
				result.Add(new XElement(UnitElementName, Unit));

			if (!string.IsNullOrWhiteSpace(Flat))
				result.Add(new XElement(IsOffice ? OfficeElementName : FlatElementName, Flat));

			if (!string.IsNullOrWhiteSpace(Comments))
				result.Add(new XElement(CommentsElementName, Comments));
		}

		private void AddStreetElement(XElement result, bool withObjectIds = true)
		{
			var streetElement = new XElement(StreetElementName);

			if (!string.IsNullOrWhiteSpace(StreetId) && withObjectIds)
				streetElement.Add(new XElement(IdElementName, StreetId));

			streetElement.Add(new XElement(NameElementName, StreetName));

			var streetTypeElement = new XElement(TypeElementName);
			if (withObjectIds)
				streetTypeElement.Add(new XElement(IdElementName, StreetTypeId));

			if (!string.IsNullOrWhiteSpace(StreetTypeFullName))
				streetTypeElement.Add(new XElement(FullNameElementName, StreetTypeFullName));

			if (!string.IsNullOrWhiteSpace(StreetTypeShortName))
				streetTypeElement.Add(new XElement(ShortNameElementName, StreetTypeShortName));

			streetElement.Add(streetTypeElement);

			result.Add(streetElement);
		}

		private void AddSettlementElement(XElement result, bool withObjectIds = true)
		{
			result.Add(Settlement.ToXml(withObjectIds));
		}

		private void FillLocationFields(LocationBuilder builder)
		{
			if (builder == null)
				throw new ArgumentNullException("builder");

			builder.Mode = (Settlement.SettlementIdValue == null) &&
				(PostAddressController.IsOtherValue(Settlement.SettlementId) ||
					!string.IsNullOrWhiteSpace(Settlement.SettlementName) ||
					(Settlement.SettlementTypeIdValue != null))
				? SettlementEntryMode.Custom
				: SettlementEntryMode.Select;
			builder.PostIndex = PostIndex;
			builder.CountryId = PostAddressController.TryParseIdOrSeparatorFromClient(
				Settlement.CountryId,
				"Некорректный идентификатор страны.");
			builder.RegionId = PostAddressController.TryParseIdOrSeparatorFromClient(
				Settlement.RegionId,
				"Некорректный идентификатор региона.");
			builder.DistrictId = PostAddressController.TryParseIdOrSeparatorFromClient(
				Settlement.DistrictId,
				"Некорректный идентификатор района.");
			builder.SettlementId = PostAddressController.TryParseIdOrSeparatorFromClient(
				Settlement.SettlementId,
				"Некорректный идентификатор населённого пункта.");

			if (builder.SettlementId == null)
			{
				builder.SettlementName = Settlement.SettlementName;
				builder.SettlementTypeId = PostAddressController.TryParseIdOrSeparatorFromClient(
					Settlement.SettlementTypeId,
					"Некорректный идентификатор типа населённого пункта.");
			}
		}
	}
}