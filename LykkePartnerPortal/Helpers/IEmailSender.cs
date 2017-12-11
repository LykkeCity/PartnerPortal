using Core.Settings.ServiceSettings;
using LykkePartnerPortal.Models.EmailTemplates;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Helpers
{
    public interface IEmailSender
    {
        Task SendEmail(IEmailTemplate model, EmailCredentialsSettings settings, string emailTo, string templateName, string subject);
    }
}
