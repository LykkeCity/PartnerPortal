using Newtonsoft.Json;

namespace LykkePartnerPortal.Models.Partners
{
    public class PartnerStatusResponseModel
    {
        [JsonProperty(PropertyName = "isApproved")]
        public bool IsApproved { get; set; }

        public static PartnerStatusResponseModel Create(bool isApproved)
        {
            return new PartnerStatusResponseModel()
            {
                IsApproved = isApproved
            };
        }
    }
}
