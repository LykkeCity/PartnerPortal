using Core.Enumerations;
using Core.Partners;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureRepositories.PartnersInformation
{
    public class PartnerInformationEntity : TableEntity, IPartnerInformation
    {
        public string ClientId { get; set; }
        public string PartnerId { get; set; }

        public int SalutationsValue { get; set; }

        public Salutations Salutations
        {
            get { return (Salutations)SalutationsValue; }
            set { SalutationsValue = (int)value; }
        }

        public int LykkeInformationValue { get; set; }

        public LykkeInformation LykkeInformation
        {
            get { return (LykkeInformation)LykkeInformationValue; }
            set { LykkeInformationValue = (int)value; }
        }

        public int SupportedRegulationsValue { get; set; }

        public SupportedRegulations SupportedRegulations
        {
            get { return (SupportedRegulations)SupportedRegulationsValue; }
            set { SupportedRegulationsValue = (int)value; }
        }

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

        public static string GeneratePartition(string organizationName)
        {
            return organizationName;
        }

        public static string GenerateRowKey(string clientId)
        {
            return clientId;
        }

        public static PartnerInformationEntity Create(IPartnerInformation partnerInfo)
        {
            return new PartnerInformationEntity
            {
                PartitionKey = GeneratePartition(partnerInfo.PartnerId),
                RowKey = GenerateRowKey(partnerInfo.ClientId),

                ClientId = partnerInfo.ClientId,
                PartnerId = partnerInfo.PartnerId,

                Salutations = partnerInfo.Salutations,
                LykkeInformation =partnerInfo.LykkeInformation,
                SupportedRegulations = partnerInfo.SupportedRegulations,

                FirstName = partnerInfo.FirstName,
                LastName = partnerInfo.LastName,
                JobTitle = partnerInfo.JobTitle,
                OrganizationName = partnerInfo.OrganizationName,
                Street = partnerInfo.Street,
                City = partnerInfo.City,
                Zip = partnerInfo.Zip,
                Country = partnerInfo.Country,
                Phone = partnerInfo.Phone,
                Email = partnerInfo.Email,
                Website = partnerInfo.Website,

                PrimaryRelationship = partnerInfo.PrimaryRelationship,
                ProposalConcern = partnerInfo.ProposalConcern,
                Description = partnerInfo.Description,

                IsApproved = partnerInfo.IsApproved
            };
        }

        public static PartnerInformationEntity Update(IPartnerInformation from, IPartnerInformation to)
        {
            from.ClientId = to.ClientId;
            from.PartnerId = to.PartnerId;

            from.Salutations = to.Salutations;
            from.LykkeInformation = to.LykkeInformation;
            from.LykkeInformation = to.LykkeInformation;

            from.FirstName = to.FirstName;
            from.LastName = to.LastName;
            from.JobTitle = to.JobTitle;
            from.OrganizationName = to.OrganizationName;
            from.Street = to.Street;
            from.City = to.City;
            from.Zip = to.Zip;
            from.Country = to.Country;
            from.Phone = to.Phone;
            from.Email = to.Email;
            from.Website = to.Website;
            from.PrimaryRelationship = to.PrimaryRelationship;
            from.ProposalConcern = to.ProposalConcern;
            from.Description = to.Description;
            from.IsApproved = to.IsApproved;

            return Create(from);
        }
    }
}
