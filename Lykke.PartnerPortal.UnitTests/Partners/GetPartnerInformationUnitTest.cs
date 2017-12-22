using Common.Log;
using LykkePartnerPortal.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Lykke.PartnerPortal.UnitTests.Partners
{
    public class GetPartnerInformationUnitTest
    {
        [Fact]
        public async Task GetPartnerInformation_ReturnNotFound()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.GetNoPartnerInformationByClientId_PartnersRepoMock();

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.GetPartnerInformation();
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task GetPartnerInformation_ReturnOkResult()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.GetPartnerInformationByClientId_PartnersRepoMock
                                                                       (PartnerInformationMocks.GetFakeClientId());

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.GetPartnerInformation();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetPartnerInformation_ReturnOkResponse()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.CheckClientIdIsTheSame_GetPartnerInfo_PartnerInfoRepoMock
                                                                    (PartnerInformationMocks.GetFakeClientId());

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.GetPartnerInformation();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetPartnerInformation_CheckClientId()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.GetPartnerInformationByClientId_PartnersRepoMock
                                                                    (PartnerInformationMocks.GetFakeClientId());

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.GetPartnerInformation();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task IsExistingPartner_ReturnOkResponse()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.GetPartnerInformationByClientId_PartnersRepoMock(PartnerInformationMocks.GetFakeClientId());

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.IsExistingPartner();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task IsExistingPartner_CheckClientId()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.CheckClientIdIsTheSame_GetPartnerInfo_PartnerInfoRepoMock(PartnerInformationMocks.GetFakeClientId());

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.IsExistingPartner();
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task GetPartnerStatus_ReturnOkResponse()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.GetPartnerInformationByClientId_PartnersRepoMock(PartnerInformationMocks.GetFakeClientId());

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.GetPartnerStatus();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetPartnerStatus_CheckClientId()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.CheckClientIdIsTheSame_GetPartnerInfo_PartnerInfoRepoMock(PartnerInformationMocks.GetFakeClientId());

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.GetPartnerStatus();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetPartnerStatus_ReturnBadRequest()
        {
            var logsMock = new Mock<ILog>();
            var partnerInformationRepo = PartnerInformationMocks.GetNoPartnerInformationByClientId_PartnersRepoMock();

            PartnersController controller = PartnerInformationMocks.GetControllerInstance(partnerInformationRepo);

            var result = await controller.GetPartnerStatus();
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
