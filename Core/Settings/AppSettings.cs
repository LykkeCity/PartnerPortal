using Core.Settings.ServiceSettings;
using Core.Settings.SlackNotifications;
using Lykke.Service.ClientAccount.Client;

namespace Core.Settings
{
    public class AppSettings
    {
        public LykkePartnerPortalSettings LykkePartnerPortal { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
        public ClientAccountServiceClientSettings ClientAccountServiceClient { get; set; }
        public SubscriberServiceClientSettings SubscriberServiceClient { get; set; }
    }
}
