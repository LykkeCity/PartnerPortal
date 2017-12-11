using Core.Settings.ServiceSettings;
using Core.Settings.SlackNotifications;

namespace Core.Settings
{
    public class AppSettings
    {
        public LykkePartnerPortalSettings LykkePartnerPortal { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
