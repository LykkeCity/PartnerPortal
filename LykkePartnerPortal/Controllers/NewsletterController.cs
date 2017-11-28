using Lykke.Messages.Email;
using LykkePartnerPortal.Models.NewsLetters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/newsLetter")]
    public class NewsletterController : Controller
    {
        private readonly IEmailSender _emailSender;

        public NewsletterController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody]NewsLetterRequestModel model)
        {
            return Ok("Subscribe!");
        }
    }
}
