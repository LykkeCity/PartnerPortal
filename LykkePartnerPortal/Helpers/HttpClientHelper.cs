using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public HttpClient GetClient()
        {
            return new HttpClient();
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            using (var client = GetClient())
            {
                return await client.PostAsync(url, content);
            }
        }

        public StringContent BuildStringContent(string postData,
            Encoding encoding, string mediaType)
        {
            return new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        public string GetPostData(string code, string clientId,
                            string clientsecret, string redirecturl)
        {
            string postData = "code=" + code;
            postData += "&client_id=" + clientId;
            postData += "&client_secret=" + clientsecret;
            postData += "&grant_type=" + "authorization_code";
            postData += "&redirect_uri=" + redirecturl;

            return postData;
        }
    }
}
