using Core.Messages;
using Lykke.Messages.Email;
using Lykke.Messages.Email.MessageData;
using System;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Helpers
{
    public class SrvEmailsFacade : ISrvEmailsFacade
    {
        private readonly IEmailSender _emailSender;

        public SrvEmailsFacade(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendContacsEmail(string partnerId, string email, string clientId)
        {
            var msgData = new KycOkData
            {
                ClientId = clientId,
                Year = DateTime.UtcNow.Year.ToString()
            };

            //await _emailSender.SendEmailAsync(partnerId, email, msgData);
        }
    }
}
