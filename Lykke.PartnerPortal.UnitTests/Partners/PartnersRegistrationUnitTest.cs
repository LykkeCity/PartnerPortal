using Common.Log;
using LykkePartnerPortal.Controllers;
using LykkePartnerPortal.Models.Partners;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Lykke.PartnerPortal.UnitTests.Partners
{
    public class PartnersRegistrationUnitTest
    {
        private PartnersController _controller;

        [Fact]
        public async Task RegisterPartner_ReturnOK()
        {
            var logsMock = new Mock<ILog>();

            var partnerInformationRepo = PartnerRegistrationMocks.Get_Create_NoPartnerInformation_PartnersRepoMock();

            _controller = new PartnersController(logsMock.Object, partnerInformationRepo);

            var result = await _controller.RegisterPartner(new PartnerRequestModel());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task RegisterPartner_ReturnBadRequestExistingPartnerInfo()
        {
            var logsMock = new Mock<ILog>();

            var partnerInformationRepo = PartnerRegistrationMocks.GetPartnerInformation_PartnersRepoMock(GetFakeClientId(),
                                                                                GetFakePartnerPublicId());

            _controller = new PartnersController(logsMock.Object, partnerInformationRepo);

            var result = await _controller.RegisterPartner(new PartnerRequestModel());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        #region Mock helper methods

        public string GetFakeClientId()
        {
            return Guid.NewGuid().ToString("N");
        }

        public List<string> GetFakePartnerPublicIds()
        {
            return new List<string>()
            {
                "test1Partner",
            };
        }

        public string GetFakePartnerPublicId()
        {
            return "test1Partner";
        }

        public string GetFakeEmail()
        {
            return "test@mail.com";
        }

        #endregion
    }
}
