using Common.Log;
using LykkePartnerPortal.Models.Contacts;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Helpers
{
    public class SendEmailManager
    {
        public static async Task SendContactEmail(string emailAccount, string emailPassword, ContactRequestModel model, ILog log)
        {
            try
            {

            }
            catch (Exception ex)
            {
                await log.WriteInfoAsync(nameof(SendEmailManager), nameof(SendContactEmail), emailAccount, ex.Message, DateTime.Now);
            }
        }
    }
}
