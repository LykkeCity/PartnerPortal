using Core.Enumerations;

namespace Core.Partners
{
    public interface IPartnerInformation
    {
        string ClientId { get; set; }
        string PartnerId { get; set; }

        Salutations Salutations { get; set; }
        LykkeInformation LykkeInformation { get; set; }
        SupportedRegulations SupportedRegulations { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }
        string JobTitle { get; set; }
        string OrganizationName { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string Zip { get; set; }
        string Country { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string Website { get; set; }

        string PrimaryRelationship { get; set; }
        string ProposalConcern { get; set; }
        string Description { get; set; }

        bool IsApproved { get; set; }
    }
}
