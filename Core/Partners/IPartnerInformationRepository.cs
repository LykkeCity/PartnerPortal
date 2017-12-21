using System.Threading.Tasks;

namespace Core.Partners
{
    public interface IPartnerInformationRepository
    {
        Task CreateAsync(IPartnerInformation partnerInfo);
        Task UpdateAsync(IPartnerInformation partnerInfo);
        Task<IPartnerInformation> GetAsync(string clientId, string organizationName);
        Task<IPartnerInformation> GetAsync(string clientId);
        Task<IPartnerInformation> GetByOrganizationNameAsync(string organizationName);
    }
}
