using System.Threading.Tasks;

namespace Core.Messages
{
    public interface ISrvEmailsFacade
    {
        Task SendContacsEmail(string partnerId, string email, string clientId);
    }
}
