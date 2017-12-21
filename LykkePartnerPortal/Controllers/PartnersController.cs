using Common.Log;
using Core.Partners;
using Lykke.Service.ClientAccount.Client;
using LykkePartnerPortal.Infrastructure.Extensions;
using LykkePartnerPortal.Models;
using LykkePartnerPortal.Models.Partners;
using LykkePartnerPortal.Strings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Authorize]
    [Route("api/partners")]
    public class PartnersController : Controller
    {
        private readonly ILog _log;
        private readonly IPartnerInformationRepository _partnerInformationRepository;

        public PartnersController(ILog log, IPartnerInformationRepository partnerInformationRepository)
        {
            _log = log;
            _partnerInformationRepository = partnerInformationRepository;
        }

        /// <summary>
        /// Register new partner.
        /// </summary>
        [HttpPost]
        [SwaggerOperation("RegisterPartner")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Models.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterPartner([FromBody]PartnerRequestModel model)
        {
            string clientId = User.GetClientId();

            var existingPartnerInformation = await _partnerInformationRepository.GetByOrganizationNameAsync(model.OrganizationName);

            if (existingPartnerInformation != null)
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.ExistingPartnerInformation });

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
        [ProducesResponseType(typeof(Models.NotFoundResponseModel), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPartnerInformation()
        {
            string clientId = User.GetClientId();

            var existingPartnerInformation = await _partnerInformationRepository.GetAsync(clientId);

            if (existingPartnerInformation == null)
                return NotFound(new Models.NotFoundResponseModel { NotFoundMessage = Phrases.NoExistingPartnerInformation });

            return Ok(PartnerResponseModel.CreateResponse(existingPartnerInformation));
        }

        /// <summary>
        /// Get information if partner is registered.
        /// </summary>
        /// <param name="clientEmail">Registered client email address. User logs in with this email.>
        /// <returns>
        /// Return information if partner is registered.
        /// </returns>
        [HttpGet("isExisting")]
        [SwaggerOperation("IsExistingPartnerInformation")]
        [ProducesResponseType(typeof(IsExistingPartnerResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> IsExistingPartner()
        {
            string clientId = User.GetClientId();

            var existingPartnerInformation = await _partnerInformationRepository.GetAsync(clientId);

            bool isExistingPartner = existingPartnerInformation != null;

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
        public async Task<IActionResult> GetPartnerStatus()
        {
            string clientId = User.GetClientId();

            var existingPartnerInformation = await _partnerInformationRepository.GetAsync(clientId);

            if (existingPartnerInformation == null)
                return BadRequest(new Models.ErrorResponse { ErrorMessage = Phrases.NoExistingPartnerInformation });

            return Ok(PartnerStatusResponseModel.Create(existingPartnerInformation.IsApproved));
        }
    }
}
