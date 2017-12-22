using Common.Log;
using Core.Partners;
using Lykke.Service.ClientAccount.Client.AutorestClient.Models;
using Lykke.Service.ClientAccount.Client.Models;
using LykkePartnerPortal.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Lykke.PartnerPortal.UnitTests.Partners
{
    public static class PartnerInformationMocks
    {
        public static IPartnerInformationRepository CheckClientIdIsTheSame_PartnerInfoRepoMock(string clientIdMocked)
        {

            var partnersInfoRepo = new Mock<IPartnerInformationRepository>();

            partnersInfoRepo.Setup(p => p.GetByOrganizationNameAsync(It.IsAny<string>()))
                                     .Returns(Task.FromResult(GetNoPartnerInformation()));

            partnersInfoRepo.Setup(p => p.CreateAsync(It.IsAny<PartnerInformation>()))
                  .Returns((PartnerInformation info) =>
                  {
                      CheckIsEqualClientId(info.ClientId, clientIdMocked);
                      return Task.FromResult("");
                  });

            return partnersInfoRepo.Object;
        }

        public static IPartnerInformationRepository Get_Create_NoPartnerInformation_PartnersRepoMock()
        {
            var partnersInfoRepo = new Mock<IPartnerInformationRepository>();

            partnersInfoRepo.Setup(p => p.GetByOrganizationNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetNoPartnerInformation()));

            partnersInfoRepo.Setup(p => p.CreateAsync(It.IsAny<PartnerInformation>())).Returns(Task.FromResult(""));

            return partnersInfoRepo.Object;
        }

        public static IPartnerInformationRepository GetPartnerInformation_PartnersRepoMock(string organization)
        {
            var partnersInfoRepo = new Mock<IPartnerInformationRepository>();

            partnersInfoRepo.Setup(p => p.GetByOrganizationNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetByOrganizationNameAsync(organization)));

            return partnersInfoRepo.Object;
        }

        public static IPartnerInformationRepository GetPartnerInformationByClientId_PartnersRepoMock(string clientId)
        {
            var partnersInfoRepo = new Mock<IPartnerInformationRepository>();

            partnersInfoRepo.Setup(p => p.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetByClientIdAsync(clientId)));

            return partnersInfoRepo.Object;
        }

        public static IPartnerInformationRepository CheckClientIdIsTheSame_GetPartnerInfo_PartnerInfoRepoMock(string clientIdMocked)
        {
            var partnersInfoRepo = new Mock<IPartnerInformationRepository>();

            partnersInfoRepo.Setup(p => p.GetAsync(It.IsAny<string>()))
                            .Returns((string clientId) =>
                            {
                                CheckIsEqualClientId(clientId, clientIdMocked);
                                return Task.FromResult(GetByClientIdAsync(clientIdMocked));
                            });

            return partnersInfoRepo.Object;
        }

        public static IPartnerInformationRepository GetNoPartnerInformationByClientId_PartnersRepoMock()
        {
            var partnersInfoRepo = new Mock<IPartnerInformationRepository>();

            partnersInfoRepo.Setup(p => p.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetNoPartnerInformation()));

            return partnersInfoRepo.Object;
        }

        public static ClaimsPrincipal MockAuthenticatedUser(string clientId)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                              {
                                     new Claim(ClaimTypes.Name, clientId)
                              }));
            return user;
        }

        public static PartnersController GetControllerInstance(IPartnerInformationRepository partnerInformationRepo)
        {
            var logsMock = new Mock<ILog>();

            PartnersController controller = new PartnersController(logsMock.Object, partnerInformationRepo);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = PartnerInformationMocks.MockAuthenticatedUser(GetFakeClientId()) }
            };

            return controller;
        }

        public static string GetFakeClientId()
        {
            return "de876be2-5fb8-43fi-9d73-15687a84d5e5";
        }

        public static string GetFakePartnerOrganizationName()
        {
            return "TestOrgName";
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

        private static IPartnerInformation GetByOrganizationNameAsync(string organization)
        {
            return new PartnerInformation()
            {
                OrganizationName = organization,
                PartnerId = organization
            };
        }

        private static IPartnerInformation GetByClientIdAsync(string clientId)
        {
            return new PartnerInformation()
            {
                ClientId = clientId
            };
        }

        private static IEnumerable<ClientAccountInformationModel> GetNoClients()
        {
            return null;
        }

        private static void CheckIsEqualClientId(string clientId, string mockedClinetId)
        {
            Assert.Equal(clientId, mockedClinetId);
        }

        #endregion
    }
}
