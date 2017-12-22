using LykkePartnerPortal.Controllers;
using LykkePartnerPortal.Models.Partners;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace Lykke.PartnerPortal.UnitTests.Partners
{
    public class PartnersRegistrationUnitTest
    {
        [Fact]
        public async Task RegisterPartner_ReturnOK()
        {
            var partnerInformationRepo = PartnerInformationMocks.Get_Create_NoPartnerInformation_PartnersRepoMock();

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.RegisterPartner(new PartnerRequestModel());
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task RegisterPartner_ReturnBadRequestExistingPartnerInfo()
        {
            var partnerInformationRepo = PartnerInformationMocks.GetPartnerInformation_PartnersRepoMock
                                                    (PartnerInformationMocks.GetFakePartnerOrganizationName());

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.RegisterPartner(new PartnerRequestModel());
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task RegisterPartner_CheckAuthenticatedUserIdIsNotChanged()
        {
            var partnerInformationRepo = PartnerInformationMocks.CheckClientIdIsTheSame_PartnerInfoRepoMock(PartnerInformationMocks.GetFakeClientId());
            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.RegisterPartner(new PartnerRequestModel());
            Assert.IsType<OkResult>(result);
        }
    }
}
