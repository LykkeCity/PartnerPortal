using Common.Log;
using LykkePartnerPortal.Helpers;
using LykkePartnerPortal.Models.Contacts;
using LykkePartnerPortal.Models.EmailTemplates;
using LykkePartnerPortal.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        protected readonly IHostingEnvironment _environment;
        private readonly EmailCredentialsSettings _emailSettings;
        private readonly ILog _log;
        //private readonly ISrvEmailsFacade _srvEmailsFacade;

        public ContactsController(EmailCredentialsSettings emailSettings, ILog log,
            //ISrvEmailsFacade srvEmailsFacade, 
            IHostingEnvironment environment)
        {
            _emailSettings = emailSettings;
            _log = log;
            //_srvEmailsFacade = srvEmailsFacade;
            _environment = environment;
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
            try
            {
                EmailSender.SendEmail(_environment, ContactTemplateModel.Create(model), _emailSettings, _emailSettings.ContactsPopUpTemplate, _emailSettings.ContactsPopUpSubject);
                return Ok();
            }
            catch (Exception ex)
            {
                await _log.WriteInfoAsync(nameof(ContactsController), nameof(SendContactInformation), ex.Message, DateTime.Now);
                return BadRequest(ex.Message);
            }
        }
    }
}
