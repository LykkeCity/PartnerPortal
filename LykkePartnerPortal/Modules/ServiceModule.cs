using Autofac;
using Common.Log;
using Lykke.SettingsReader;
using LykkePartnerPortal.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<LykkePartnerPortalSettings> _settings;
        private readonly ILog _log;
        //private readonly IServiceCollection _services;

        public ServiceModule(IReloadingManager<LykkePartnerPortalSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;
            //_services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterLocalTypes(builder);

            builder.RegisterInstance(_settings.CurrentValue.EmailCredentials);
        }

        private void RegisterLocalTypes(ContainerBuilder builder)
        {
            builder.RegisterInstance(_log).As<ILog>().SingleInstance();
        }
    }
}
