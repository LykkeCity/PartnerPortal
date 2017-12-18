﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using AzureRepositories;
using Common.Log;
using Core.Partners;
using Core.Services;
using Core.Settings;
using Lykke.PartnerPortal.Services;
using Lykke.Service.ClientAccount.Client;
using Lykke.Service.Subscribers.Client;
using Lykke.SettingsReader;
using LykkePartnerPortal.Helpers;
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
            RegisterLocalServices(builder);
            RegisterExternalServices(builder);

            builder.RegisterInstance(_settings.CurrentValue.LykkePartnerPortal.EmailCredentials);
            builder.RegisterInstance(_settings.CurrentValue.LykkePartnerPortal.ProductsInformation);

            builder.RegisterInstance<IPartnerInformationRepository>(
                  AzureRepoBinder.CreatePartnerInformationRepository(_settings.ConnectionString(x => x.LykkePartnerPortal.Db.ClientPersonalInfoConnString), _log)).
              SingleInstance();

            builder.Populate(_services);
        }

        private static void RegisterLocalServices(ContainerBuilder builder)
        {
            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();
        }

        private void RegisterLocalTypes(ContainerBuilder builder)
        {
            builder.RegisterInstance(_log).As<ILog>().SingleInstance();
        }

        private void RegisterExternalServices(ContainerBuilder builder)
        {
            builder.RegisterSubscriberClient(_settings.CurrentValue.LykkePartnerPortal.Services.SubscriberServiceUrl, _log);

            builder.RegisterLykkeServiceClient(_settings.CurrentValue.ClientAccountServiceClient.ServiceUrl);

            builder.RegisterType<EmailSender>().As<IEmailSender>().SingleInstance();
        }
    }
}
