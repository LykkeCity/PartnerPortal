using Common.Log;
using Lykke.Service.Subscribers.Client;
using LykkePartnerPortal.Helpers;
using LykkePartnerPortal.Models.EmailTemplates;
using LykkePartnerPortal.Models.NewsLetters;
using LykkePartnerPortal.Settings;
using LykkePartnerPortal.Strings;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/newsLetter")]
    public class NewsletterController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ISubscribersClient _subscribersClient;
        private readonly EmailCredentialsSettings _emailSettings;
        protected readonly ILog _log;

        public NewsletterController(IEmailSender emailSender,
            ISubscribersClient subscribersClient, EmailCredentialsSettings emailSettings, ILog log)
        {
            _emailSender = emailSender;
            _subscribersClient = subscribersClient;
            _emailSettings = emailSettings;
            _log = log;
        }

        /// <summary>
        /// Check if subscriber exists
        /// </summary>
        [HttpPost("checkIsExistingSubscriber")]
        [SwaggerOperation("CheckIsExistingSubscriber")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckIsExistingSubscriber([FromBody]NewsLetterRequestModel model)
        {
            var result = await _subscribersClient.GetByEmailAsync(model.Source, model.Email);
            return Ok(result != null);
        }

        /// <summary>
        /// Create new subscriber and send email to partners@lykke.com.
        /// </summary>
        [HttpPost]
        [SwaggerOperation("Subscribe")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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

                _emailSender.SendEmail(NewsletterTemplateModel.Create(model), _emailSettings, _emailSettings.NewsletterTemplate, _emailSettings.NewsletterSubject);

                return Ok();
            }
            catch (Exception ex)
            {
                await _log.WriteInfoAsync(nameof(NewsletterController), nameof(Subscribe), ex.Message, DateTime.Now);
                return BadRequest(ex.Message);
            }
        }
    }
}
