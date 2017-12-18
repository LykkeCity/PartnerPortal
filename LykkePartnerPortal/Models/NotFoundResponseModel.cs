using Newtonsoft.Json;

namespace LykkePartnerPortal.Models
{
    public class NotFoundResponseModel
    {
        [JsonProperty(PropertyName = "notFoundMessage")]
        public string NotFoundMessage { get; set; }
    }
}
