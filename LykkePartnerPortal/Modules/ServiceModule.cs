using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Log;
using Lykke.Service.Subscribers.Client;
using Lykke.SettingsReader;
using LykkePartnerPortal.Helpers;
using LykkePartnerPortal.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace LykkePartnerPortal.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _settings;
        private readonly ILog _log;
        private readonly IServiceCollection _services;

        public ServiceModule(IReloadingManager<AppSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;
            _services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterLocalTypes(builder);
            RegisterExternalServices(builder);

            builder.RegisterInstance(_settings.CurrentValue.LykkePartnerPortal.EmailCredentials);
            builder.Populate(_services);
        }

        private void RegisterLocalTypes(ContainerBuilder builder)
        {
            builder.RegisterInstance(_log).As<ILog>().SingleInstance();
        }

        private void RegisterExternalServices(ContainerBuilder builder)
        {
            builder.RegisterType<SubscribersClient>()
              .As<ISubscribersClient>()
              .WithParameter("serviceUrl", _settings.CurrentValue.SubscriberServiceClient.ServiceUrl)
              .WithParameter("log", _log)
              .WithParameter("timeout", _settings.CurrentValue.SubscriberServiceClient.RequestTimeout)
              .SingleInstance();

            builder.RegisterType<EmailSender>().As<IEmailSender>().SingleInstance();
        }
    }
}
