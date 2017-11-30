using LykkePartnerPortal.Models.EmailTemplates;
using LykkePartnerPortal.Settings;

namespace LykkePartnerPortal.Helpers
{
    public interface IEmailSender
    {
        void SendEmail(IEmailTemplate model, EmailCredentialsSettings settings, string templateName, string subject);
    }
}
