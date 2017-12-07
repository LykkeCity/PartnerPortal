using Core.Settings.ServiceSettings;
using LykkePartnerPortal.Models.EmailTemplates;

namespace LykkePartnerPortal.Helpers
{
    public interface IEmailSender
    {
        void SendEmail(IEmailTemplate model, EmailCredentialsSettings settings, string emailTo, string templateName, string subject);
    }
}
