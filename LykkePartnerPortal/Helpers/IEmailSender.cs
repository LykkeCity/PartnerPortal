using LykkePartnerPortal.Models.EmailTemplates;
using LykkePartnerPortal.Settings;

namespace LykkePartnerPortal.Helpers
{
    public interface IEmailSender
    {
        void SendEmail(IEmailTemplate model, EmailCredentialsSettings settings, string emailTo, string templateName, string subject);
    }
}
