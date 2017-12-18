using AzureStorage;
using Core.Partners;
using System.Linq;
using System.Threading.Tasks;

namespace AzureRepositories.PartnersInformation
{
    public class PartnerInformationRepository : IPartnerInformationRepository
    {
        private readonly INoSQLTableStorage<PartnerInformationEntity> _tableStorage;

        public PartnerInformationRepository(INoSQLTableStorage<PartnerInformationEntity> tableStorage)
        {
            _tableStorage = tableStorage;
        }

        public Task CreateAsync(IPartnerInformation partnerInfo)
        {
            var entity = PartnerInformationEntity.Create(partnerInfo);
            return _tableStorage.InsertAsync(entity);
        }

        public async Task UpdateAsync(IPartnerInformation partnerInfo)
        {
            var entity =
                    await
                        _tableStorage.GetDataAsync(PartnerInformationEntity.GeneratePartition(partnerInfo.PartnerId),
                            PartnerInformationEntity.GenerateRowKey(partnerInfo.ClientId));

            PartnerInformationEntity.Update(entity, partnerInfo);

            await _tableStorage.InsertOrReplaceAsync(entity);
        }

        public async Task ChangePartnerAprovedStatus(bool approved, string partnerId, string clientId)
        {
            await _tableStorage.MergeAsync(PartnerInformationEntity.GeneratePartition(partnerId),
                PartnerInformationEntity.GenerateRowKey(clientId),
                p =>
                {
                    p.IsApproved = approved;
                    return p;
                });
        }

        public async Task<IPartnerInformation> GetAsync(string clientId, string partnerId)
        {
            return await _tableStorage.GetDataAsync(PartnerInformationEntity.GeneratePartition(partnerId), PartnerInformationEntity.GenerateRowKey(clientId));
        }

        public async Task<IPartnerInformation> GetAsync(string clientId)
        {
            return (await _tableStorage.GetDataAsync(f=>f.ClientId == clientId)).FirstOrDefault();
        }
    }
}
