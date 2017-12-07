using Common.Log;
using LykkePartnerPortal.Helpers;
using LykkePartnerPortal.Models.Contacts;
using LykkePartnerPortal.Models.EmailTemplates;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Core.Settings.ServiceSettings;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        private readonly EmailCredentialsSettings _emailSettings;
        private readonly ILog _log;
        private readonly IEmailSender _emailSender;

        public ContactsController(EmailCredentialsSettings emailSettings, ILog log, IEmailSender emailSender)
        {
            _emailSettings = emailSettings;
            _log = log;
            _emailSender = emailSender;
        }

        /// <summary>
        /// Send email with contacts information to partners@lykke.com.
        /// </summary>
        [HttpPost("sendContact")]
        [SwaggerOperation("SendContactInformation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SendContactInformation([FromBody]ContactRequestModel model)
        {
            _emailSender.SendEmail(ContactTemplateModel.Create(model), _emailSettings, _emailSettings.EmailTo,
                _emailSettings.ContactsPopUpTemplate, _emailSettings.ContactsPopUpSubject);

            return Ok();
        }
    }
}
