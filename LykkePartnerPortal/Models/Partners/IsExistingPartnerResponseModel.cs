using Newtonsoft.Json;

namespace LykkePartnerPortal.Models.Partners
{
    public class IsExistingPartnerResponseModel
    {
        [JsonProperty(PropertyName = "isExisting")]
        public bool IsExisting { get; set; }

        public static IsExistingPartnerResponseModel Create(bool isExisting)
        {
            return new IsExistingPartnerResponseModel()
            {
                IsExisting = isExisting
            };
        }
    }
}
