﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Log;
using Core.Messages;
using Lykke.Messages.Email;
using Lykke.Service.Subscribers.Client;
using Lykke.SettingsReader;
using LykkePartnerPortal.Helpers;
using LykkePartnerPortal.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace LykkePartnerPortal.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<LykkePartnerPortalSettings> _settings;
        private readonly ILog _log;
        private readonly IServiceCollection _services;

        public ServiceModule(IReloadingManager<LykkePartnerPortalSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;
            _services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterLocalTypes(builder);
            RegisterExternalServices(builder);

            builder.RegisterInstance(_settings.CurrentValue.EmailCredentials);
            builder.Populate(_services);
        }

        private void RegisterLocalTypes(ContainerBuilder builder)
        {
            builder.RegisterInstance(_log).As<ILog>().SingleInstance();
        }

        private void RegisterExternalServices(ContainerBuilder builder)
        {
            //builder.RegisterEmailSenderViaInmemoryQueueMessageProducer();

            builder.RegisterEmailSenderViaAzureQueueMessageProducer(_settings.ConnectionString(x => x.Db.ClientPersonalInfoConnString), "emailsqueue");

            builder.RegisterType<SubscribersClient>()
              .As<ISubscribersClient>()
              .WithParameter("serviceUrl", _settings.CurrentValue.SubscriberService.ServiceUrl)
              .WithParameter("log", _log)
              .WithParameter("timeout", _settings.CurrentValue.SubscriberService.RequestTimeout)
              .SingleInstance();

            builder.RegisterType<SrvEmailsFacade>().As<ISrvEmailsFacade>().SingleInstance();

        }
    }
}
