using LykkePartnerPortal.Models.EmailTemplates;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using Core.Settings;
using Core.Settings.ServiceSettings;

namespace LykkePartnerPortal.Helpers
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(IEmailTemplate model, EmailCredentialsSettings settings, string emailTo, string templateName, string subject)
        {
            MailAddress from = new MailAddress(settings.EmailAccount);
            MailAddress to = new MailAddress(emailTo);

            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = true;
            message.Subject = subject;

            string body = FileHelper.Load(settings.EmailsTemplatesFolder, templateName);
            message.Body = ReplaceText(model, body);

            CreateMailClient(settings).Send(message);
        }

        private SmtpClient CreateMailClient(EmailCredentialsSettings settings)
        {
            var client = new SmtpClient();

            client.UseDefaultCredentials = settings.UseDefaultCredentials;
            client.Host = settings.Host;
            client.Port = settings.Port;
            client.EnableSsl = settings.EnableSsl;
            client.Credentials =
                new NetworkCredential(settings.EmailAccount, settings.EmailPassword);

            return client;
        }

        private string ReplaceText(IEmailTemplate model, string body)
        {
            foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
            {
                string propertyName = "@[" + propertyInfo.Name + "]";
                string propertyValue = propertyInfo.GetValue(model, null)?.ToString();

                body = body.Replace(propertyName, propertyValue);
            }

            return body;
        }
    }
}
