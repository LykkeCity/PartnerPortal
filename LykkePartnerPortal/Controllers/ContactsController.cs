using Common.Log;
using LykkePartnerPortal.Helpers;
using LykkePartnerPortal.Models.Contacts;
using LykkePartnerPortal.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        private readonly EmailCredentialsSettings _emailSettings;
        private readonly ILog _log;

        public ContactsController(EmailCredentialsSettings emailSettings, ILog log)
        {
            _emailSettings = emailSettings;
            _log = log;
        }

        [HttpPost("sendContact")]
        public async Task<IActionResult> SendContactInformation([FromBody]ContactRequestModel model)
        {
            await SendEmailManager.SendContactEmail(_emailSettings.EmailAccount, _emailSettings.EmailPassword, model, _log);

            return Ok(model);
        }
    }
}
