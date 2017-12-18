using Core.Enumerations;

namespace Core.Partners
{
    public class PartnerInformation : IPartnerInformation
    {
        public string ClientId { get; set; }
        public string PartnerId { get; set; }

        public Salutations Salutations { get; set; }
        public LykkeInformation LykkeInformation { get; set; }
        public SupportedRegulations SupportedRegulations { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string OrganizationName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public string PrimaryRelationship { get; set; }
        public string ProposalConcern { get; set; }
        public string Description { get; set; }

        public bool IsApproved { get; set; }
    }
}
