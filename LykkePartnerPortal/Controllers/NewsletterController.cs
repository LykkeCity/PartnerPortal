using Lykke.Messages.Email;
using Lykke.Service.Subscribers.Client;
using LykkePartnerPortal.Models.NewsLetters;
using LykkePartnerPortal.Strings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/newsLetter")]
    public class NewsletterController : Controller
    {
        //private readonly IEmailSender _emailSender;
        private readonly ISubscribersClient _subscribersClient;

        public NewsletterController(
            //IEmailSender emailSender, 
            ISubscribersClient subscribersClient)
        {
            //_emailSender = emailSender;
            _subscribersClient = subscribersClient;
        }

        [HttpPost("checkIsExistingSubscriber")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckIsExistingSubscriber([FromBody]NewsLetterRequestModel model)
        {
            var result = await _subscribersClient.GetByEmailAsync(model.Source, model.Email);
            return Ok(result != null);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Subscribe([FromBody]NewsLetterRequestModel model)
        {
            try
            {
                var result = await _subscribersClient.GetByEmailAsync(model.Source, model.Email);

                if (result != null)
                    return BadRequest(Phrases.SubscriberAlreadyExists);

                await _subscribersClient.CreateSubscriber(new Lykke.Service.Subscribers.Client.AutorestClient.Models.SubscriberRequestModel()
                {
                    Email = model.Email,
                    Source = model.Source
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
