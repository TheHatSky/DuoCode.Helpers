using System.Collections.Generic;
using System.Globalization;
using Itc.DirectCrm.Model;

namespace Mindbox.PostAddress
{

	public class PostIndexViewModel : PostAddressDictionariesViewModel
	{

		public PostIndexViewModel()
		{
			SelectedStreetTypeId = PostAddressController.EmptyValue;
		}


		public string Street { get; set; }
		public string SelectedStreetTypeId { get; private set; }


		public void SetSelectedStreetType(ObjectType streetType)
		{
			SetSelectedStreetTypeId(streetType == null ? default(int?) : streetType.Id);
		}

		public void SetSelectedStreetTypeId(int? streetTypeId)
		{
			SelectedStreetTypeId = streetTypeId == null ?
				PostAddressController.EmptyValue :
				streetTypeId.Value.ToString(CultureInfo.InvariantCulture);
		}

		public void SetStreet(Street street)
		{
			Street = street == null ? null : street.Name;
			SetSelectedStreetType(street == null ? null : street.ObjectType);
		}

		public override Dictionary<string, object> ToJson()
		{
			var json = base.ToJson();
			json.Add("street", Street);
			json.Add("selectedStreetType", SelectedStreetTypeId);
			return json;
		}
	}

}
