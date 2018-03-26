using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Helpers
{
    public interface IHttpClientHelper
    {
        HttpClient GetClient();
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
        StringContent BuildStringContent(string postData, Encoding encoding, string mediaType);
        string GetPostData(string code, string clientId, string clientsecret, string redirecturl);
    }
}
