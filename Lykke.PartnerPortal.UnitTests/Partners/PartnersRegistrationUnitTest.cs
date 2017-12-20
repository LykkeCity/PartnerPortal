using Common.Log;
using Lykke.Service.ClientAccount.Client;
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
            var partnersClient = PartnerRegistrationMocks.GetNoPartners_PatnersClientMock();
            var clientAccountClient = PartnerRegistrationMocks.GetClientsByEmail_ClientAccountClientMock
                                                                    (GetFakeEmail(), GetFakeClientId());
            var partnerInformationRepo = PartnerRegistrationMocks.Get_Create_NoPartnerInformation_PartnersRepoMock();

            _controller = new PartnersController(logsMock.Object, partnersClient,
                                            clientAccountClient, partnerInformationRepo);

            var result = await _controller.RegisterPartner(new PartnerRequestModel());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task RegisterPartner_ReturnNotFoundClient()
        {
            var logsMock = new Mock<ILog>();
            var partnersClient = PartnerRegistrationMocks.GetNoPartners_PatnersClientMock();
            var clientAccountClient = PartnerRegistrationMocks.GetNoClientsByEmail_ClientAccountClientMock();
            var partnerInformationRepo = PartnerRegistrationMocks.Get_Create_NoPartnerInformation_PartnersRepoMock();

            _controller = new PartnersController(logsMock.Object, partnersClient,
                                            clientAccountClient, partnerInformationRepo);

            var result = await _controller.RegisterPartner(new PartnerRequestModel());

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task RegisterPartner_ReturnBadRequestExistingPartnerInfo()
        {
            var logsMock = new Mock<ILog>();
            var partnersClient = PartnerRegistrationMocks.GetNoPartners_PatnersClientMock();
            var clientAccountClient = PartnerRegistrationMocks.GetClientsByEmail_ClientAccountClientMock
                                                                (GetFakeEmail(), GetFakeClientId());
            var partnerInformationRepo = PartnerRegistrationMocks.GetPartnerInformation_PartnersRepoMock(GetFakeClientId(),
                                                                            GetFakePartnerPublicId());

            _controller = new PartnersController(logsMock.Object, partnersClient,
                                            clientAccountClient, partnerInformationRepo);

            var result = await _controller.RegisterPartner(new PartnerRequestModel());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task RegisterPartner_ReturnBadRequestExistingPartner()
        {
            var logsMock = new Mock<ILog>();
            var partnersClient = PartnerRegistrationMocks.GetPartners_PatnersClientMock(GetFakePartnerPublicIds());

            var clientAccountClient = PartnerRegistrationMocks.GetClientsByEmail_ClientAccountClientMock
                                                          (GetFakeEmail(), GetFakeClientId());
            var partnerInformationRepo = PartnerRegistrationMocks.Get_Create_NoPartnerInformation_PartnersRepoMock();

            _controller = new PartnersController(logsMock.Object, partnersClient,
                                            clientAccountClient, partnerInformationRepo);

            var result = await _controller.RegisterPartner(new PartnerRequestModel());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CheckIfClientEmailIsNotChanged()
        {
            var logsMock = new Mock<ILog>();
           
            var clientAccountClient = PartnerRegistrationMocks.CheckClientEmail_ClientAccountClientMock
                                                          (GetFakeEmail(), GetFakeClientId());

            var partnersClient = PartnerRegistrationMocks.GetNoPartners_PatnersClientMock();
            var partnerInformationRepo = PartnerRegistrationMocks.Get_Create_NoPartnerInformation_PartnersRepoMock();

            _controller = new PartnersController(logsMock.Object, partnersClient,
                                            clientAccountClient, partnerInformationRepo);

            var result = await _controller.RegisterPartner(new PartnerRequestModel()
            {
                Email = GetFakeEmail(),
                ClientEmail = GetFakeEmail()
            });

            Assert.IsType<OkResult>(result);
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
