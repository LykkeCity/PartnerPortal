using Core.Partners;
using LykkePartnerPortal.Helpers;
using Newtonsoft.Json;

namespace LykkePartnerPortal.Models.Partners
{
    public class PartnerResponseModel : BasePartnerModel
    {
        [JsonProperty(PropertyName = "isApproved")]
        public bool IsApproved { get; set; }

        [JsonProperty(PropertyName = "salutations")]
        public string Salutations { get; set; }

        [JsonProperty(PropertyName = "lykkeInformation")]
        public string LykkeInformation { get; set; }

        [JsonProperty(PropertyName = "supportedRegulations")]
        public string SupportedRegulations { get; set; }

        public static PartnerResponseModel CreateResponse(IPartnerInformation partnerInformation)
        {
            return new PartnerResponseModel()
            {
                Salutations = EnumExtensions.GetDisplayName(partnerInformation.Salutations),
                LykkeInformation = EnumExtensions.GetDisplayName(partnerInformation.LykkeInformation),
                SupportedRegulations = EnumExtensions.GetDisplayName(partnerInformation.SupportedRegulations),

                FirstName = partnerInformation.FirstName,
                LastName = partnerInformation.LastName,
                JobTitle = partnerInformation.JobTitle,
                OrganizationName = partnerInformation.OrganizationName,
                Street = partnerInformation.Street,
                City = partnerInformation.City,
                Zip = partnerInformation.Zip,
                Country = partnerInformation.Country,
                Phone = partnerInformation.Phone,
                Email = partnerInformation.Email,
                Website = partnerInformation.Website,

                PrimaryRelationship = partnerInformation.PrimaryRelationship,
                ProposalConcern = partnerInformation.ProposalConcern,
                Description = partnerInformation.Description,

                IsApproved = partnerInformation.IsApproved
            };
        }
    }
}
