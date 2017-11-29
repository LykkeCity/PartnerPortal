﻿using LykkePartnerPortal.Models.Contacts;
using LykkePartnerPortal.Models.EmailTemplates;
using LykkePartnerPortal.Settings;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace LykkePartnerPortal.Helpers
{
    public static class EmailSender
    {
        private static SmtpClient CreateMailClient(EmailCredentialsSettings settings)
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

        public static void SendEmail(IEmailTemplate model, EmailCredentialsSettings settings, string templateName, string subject)
        {
            MailAddress from = new MailAddress(settings.EmailAccount);
            MailAddress to = new MailAddress(settings.EmailTo);

            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = true;
            message.Subject = subject;

            string body = FileHelper.Load(settings.EmailsTemplatesFolder, templateName);
            message.Body = ReplaceText(model, body);

            CreateMailClient(settings).Send(message);
        }

        private static string ReplaceText(IEmailTemplate model, string body)
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
