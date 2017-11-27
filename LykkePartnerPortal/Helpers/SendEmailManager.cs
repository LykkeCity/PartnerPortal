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
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("dafinkagerdjikova@gmail.com");
                mail.To.Add("dafinka.gerdjikova@programista.pro");
                mail.Subject = "New Contact Subscription";
                mail.Body = "Contact name: " + model.FullName;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emailAccount, emailPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                await log.WriteInfoAsync(nameof(SendEmailManager), nameof(SendContactEmail), emailAccount, ex.Message, DateTime.Now);
            }
        }
    }
}
