using AzureRepositories.PartnersInformation;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;

namespace AzureRepositories
{
    public static class AzureRepoBinder
    {
        public static PartnerInformationRepository CreatePartnerInformationRepository(IReloadingManager<string> connString, ILog log)
        {
            return new PartnerInformationRepository(AzureTableStorage<PartnerInformationEntity>.Create(connString, "PartnersInformation", log));
        }
    }
}
