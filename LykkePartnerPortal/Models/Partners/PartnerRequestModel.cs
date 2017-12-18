using Core.Enumerations;
using Core.Partners;
using Newtonsoft.Json;

namespace LykkePartnerPortal.Models.Partners
{
    public class PartnerRequestModel : BasePartnerModel
    {
        [JsonProperty(PropertyName = "clientEmail")]
        public string ClientEmail { get; set; }

        [JsonProperty(PropertyName = "salutations")]
        public Salutations Salutations { get; set; }

        [JsonProperty(PropertyName = "lykkeInformation")]
        public LykkeInformation LykkeInformation { get; set; }

        [JsonProperty(PropertyName = "supportedRegulations")]
        public SupportedRegulations SupportedRegulations { get; set; }

        public static PartnerInformation CreatePartnerInformation(PartnerRequestModel model, string publicPartnerId, string clientId)
        {
            return new PartnerInformation()
            {
                ClientId = clientId,
                PartnerId = publicPartnerId,

                Salutations = model.Salutations,
                LykkeInformation = model.LykkeInformation,
                SupportedRegulations = model.SupportedRegulations,

                FirstName = model.FirstName,
                LastName = model.LastName,
                JobTitle = model.JobTitle,
                OrganizationName = model.OrganizationName,
                Street = model.Street,
                City = model.City,
                Zip = model.Zip,
                Country = model.Country,
                Phone = model.Phone,
                Email = model.Email,
                Website = model.Website,

                PrimaryRelationship = model.PrimaryRelationship,
                ProposalConcern = model.ProposalConcern,
                Description = model.Description,

                IsApproved = false
            };
        }
    }
}
