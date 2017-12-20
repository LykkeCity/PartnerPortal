using Core.Partners;
using Lykke.Service.ClientAccount.Client;
using Lykke.Service.ClientAccount.Client.AutorestClient.Models;
using Lykke.Service.ClientAccount.Client.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Lykke.PartnerPortal.UnitTests.Partners
{
    public static class PartnerRegistrationMocks
    {
        public static IClientAccountClient CheckClientEmail_ClientAccountClientMock(string email, string clientId)
        {
            var clientAccountClient = new Mock<IClientAccountClient>();
            clientAccountClient.Setup(c => c.GetClientsByEmailAsync(It.IsAny<string>()))
                .Returns((string clientEmail) =>
                {
                    CheckIsEqualEmail(clientEmail, email);
                    return Task.FromResult(GetClients(email, clientId));
                });

            return clientAccountClient.Object;
        }

        public static IClientAccountClient GetClientsByEmail_ClientAccountClientMock(string email, string clientId)
        {
            var clientAccountClient = new Mock<IClientAccountClient>();
            clientAccountClient.Setup(c => c.GetClientsByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetClients(email, clientId)));

            return clientAccountClient.Object;
        }

        public static IClientAccountClient GetNoClientsByEmail_ClientAccountClientMock()
        {
            var clientAccountClient = new Mock<IClientAccountClient>();
            clientAccountClient.Setup(c => c.GetClientsByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetNoClients()));

            return clientAccountClient.Object;
        }

        public static IPartnersClient GetNoPartners_PatnersClientMock()
        {
            var partnersClient = new Mock<IPartnersClient>();
            partnersClient.Setup(p => p.FindByPublicIdsAsync(It.IsAny<string[]>()))
                .Returns(Task.FromResult(GetNoPartners()));

            return partnersClient.Object;
        }

        public static IPartnersClient GetPartners_PatnersClientMock(List<string> publicIds)
        {
            var partnersClient = new Mock<IPartnersClient>();
            partnersClient.Setup(p => p.FindByPublicIdsAsync(It.IsAny<List<string>>()))
                .Returns(Task.FromResult(GetPartners(publicIds)));

            return partnersClient.Object;
        }

        public static IPartnerInformationRepository Get_Create_NoPartnerInformation_PartnersRepoMock()
        {
            var partnersInfoRepo = new Mock<IPartnerInformationRepository>();

            partnersInfoRepo.Setup(p => p.GetAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(GetNoPartnerInformation()));

            partnersInfoRepo.Setup(p => p.CreateAsync(It.IsAny<PartnerInformation>())).Returns(Task.FromResult(""));

            return partnersInfoRepo.Object;
        }

        public static IPartnerInformationRepository GetPartnerInformation_PartnersRepoMock(string clientId, string organization)
        {
            var partnersInfoRepo = new Mock<IPartnerInformationRepository>();

            partnersInfoRepo.Setup(p => p.GetAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(GetPartnerInformation(clientId, organization)));

            return partnersInfoRepo.Object;
        }


        #region private methods
        private static IEnumerable<ClientAccountInformationModel> GetClients(string email, string clientId)
        {
            return new List<ClientAccountInformationModel>()
            {
                new ClientAccountInformationModel()
                {
                    Email = email,
                    Id = clientId
                }
            };
        }

        private static IEnumerable<Partner> GetNoPartners()
        {
            return new List<Partner>();
        }

        private static IEnumerable<Partner> GetPartners(List<string> publicIds)
        {
            List<Partner> result = new List<Partner>();

            foreach (var id in publicIds)
            {
                result.Add(new Partner() { PublicId = id });
            }

            return result.AsEnumerable();
        }

        private static IPartnerInformation GetNoPartnerInformation()
        {
            return null;
        }

        private static IPartnerInformation GetPartnerInformation(string clientId, string organization)
        {
            return new PartnerInformation()
            {
                ClientId = clientId,
                OrganizationName = organization,
                PartnerId = organization
            };
        }

        private static IEnumerable<ClientAccountInformationModel> GetNoClients()
        {
            return null;
        }

        private static void CheckIsEqualEmail(string email, string mockedEmail)
        {
            Assert.Equal(email, mockedEmail);
        }

        #endregion
    }
}
