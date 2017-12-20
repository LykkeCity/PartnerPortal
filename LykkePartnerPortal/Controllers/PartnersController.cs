using Common.Log;
using Core.Partners;
using Lykke.Service.ClientAccount.Client;
using LykkePartnerPortal.Models;
using LykkePartnerPortal.Models.Partners;
using LykkePartnerPortal.Strings;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/partners")]
    public class PartnersController : Controller
    {
        private readonly ILog _log;
        private readonly IPartnersClient _partnersClient;
        private readonly IClientAccountClient _clientAccountClient;
        private readonly IPartnerInformationRepository _partnerInformationRepository;

        public PartnersController(ILog log, IPartnersClient partnersClient, IClientAccountClient clientAccountClient,
            IPartnerInformationRepository partnerInformationRepository)
        {
            _log = log;
            _partnersClient = partnersClient;
            _clientAccountClient = clientAccountClient;
            _partnerInformationRepository = partnerInformationRepository;
        }

        /// <summary>
        /// Register new partner.
        /// </summary>
        [HttpPost]
        [SwaggerOperation("RegisterPartner")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Models.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NotFoundResponseModel), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> RegisterPartner([FromBody]PartnerRequestModel model)
        {
            var registeredClient = await _clientAccountClient.GetClientsByEmailAsync(model.ClientEmail);

            if (registeredClient == null || registeredClient.Count() <= 0)
                return NotFound(new NotFoundResponseModel() { NotFoundMessage = Phrases.UserNotFound });

            List<string> partnerIds = new List<string>()
            {
                model.OrganizationName
            };

            var existingPartners = await _partnersClient.FindByPublicIdsAsync(partnerIds);

            if (existingPartners != null && existingPartners.Count() > 0)
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.ExistingPartner });


            string clientId = registeredClient.FirstOrDefault().Id;


            var existingPartner = await _partnerInformationRepository.GetAsync(clientId, model.OrganizationName);

            if (existingPartner != null)
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.ExistingPartner });

            //await _partnersClient.CreatePartnerAsync(new Partner()
            //{
            //    PublicId = model.OrganizationName,
            //    InternalId = Guid.NewGuid().ToString("N"),
            //    Name = model.OrganizationName
            //});

            await _partnerInformationRepository.CreateAsync(PartnerRequestModel.CreatePartnerInformation(model, model.OrganizationName, clientId));
            return Ok();
        }

        /// <summary>
        /// Get Partner Information.
        /// </summary>
        /// <param name="clientEmail">Registered client email address. User logs in with this email.>
        /// <returns>
        /// Returns partner information of logged user, if there is registered partner.
        /// </returns>
        [HttpGet]
        [SwaggerOperation("GetPartnerInformation")]
        [ProducesResponseType(typeof(PartnerResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Models.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NotFoundResponseModel), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPartnerInformation([FromQuery] string clientEmail)
        {
            if (string.IsNullOrEmpty(clientEmail))
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.InvalidEmailFormat });

            var registeredClient = (await _clientAccountClient.GetClientsByEmailAsync(clientEmail)).FirstOrDefault();

            if (registeredClient == null)
                return NotFound(new NotFoundResponseModel() { NotFoundMessage = Phrases.UserNotFound });

            var existingPartner = await _partnerInformationRepository.GetAsync(registeredClient.Id);

            if (existingPartner == null)
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.NoExistingPartner });

            return Ok(PartnerResponseModel.CreateResponse(existingPartner));
        }

        /// <summary>
        /// Get information if partner is registered.
        /// </summary>
        /// <param name="clientEmail">Registered client email address. User logs in with this email.>
        /// <returns>
        /// Return information if partner is registered.
        /// </returns>
        [HttpGet("isExisting")]
        [SwaggerOperation("IsExistingPartner")]
        [ProducesResponseType(typeof(IsExistingPartnerResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Models.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NotFoundResponseModel), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> IsExistingPartner([FromQuery] string clientEmail)
        {
            if (string.IsNullOrEmpty(clientEmail))
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.InvalidEmailFormat });

            var registeredClient = (await _clientAccountClient.GetClientsByEmailAsync(clientEmail)).FirstOrDefault();

            if (registeredClient == null)
                return NotFound(new NotFoundResponseModel() { NotFoundMessage = Phrases.UserNotFound });

            var existingPartner = await _partnerInformationRepository.GetAsync(registeredClient.Id);

            bool isExistingPartner = existingPartner != null;

            return Ok(IsExistingPartnerResponseModel.Create(isExistingPartner));
        }

        /// <summary>
        /// Get Partner Status.
        /// </summary>
        /// <param name="clientEmail">Registered client email address. User logs in with this email.>
        /// <returns>
        /// Return information if registered partner was approved.
        /// </returns>
        [HttpGet("status")]
        [SwaggerOperation("GetPartnerStatus")]
        [ProducesResponseType(typeof(PartnerStatusResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Models.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NotFoundResponseModel), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPartnerStatus([FromQuery] string clientEmail)
        {
            if (string.IsNullOrEmpty(clientEmail))
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.InvalidEmailFormat });

            var registeredClient = (await _clientAccountClient.GetClientsByEmailAsync(clientEmail)).FirstOrDefault();

            if (registeredClient == null)
                return NotFound(new NotFoundResponseModel() { NotFoundMessage = Phrases.UserNotFound });

            var existingPartner = await _partnerInformationRepository.GetAsync(registeredClient.Id);

            if (existingPartner == null)
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.NoExistingPartner });

            return Ok(PartnerStatusResponseModel.Create(existingPartner.IsApproved));
        }
    }
}
