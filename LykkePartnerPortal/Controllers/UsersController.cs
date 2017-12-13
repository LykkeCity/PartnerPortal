using Common.Log;
using Core.Settings.ServiceSettings;
using LykkePartnerPortal.Helpers;
using LykkePartnerPortal.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        protected readonly ILog _log;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IHttpClientHelper _client;

        public UsersController(ILog log, AuthenticationSettings authenticationSettings, IHttpClientHelper client)
        {
            _log = log;
            _authenticationSettings = authenticationSettings;
            _client = client;
        }

        /// <summary>
        /// Single sign on authentication
        /// </summary>
        [HttpPost]
        [SwaggerOperation("Authentication")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Authentication([FromBody] SingleSignOnRequestModel model)
        {
            string postData = _client.GetPostData(model.Code, _authenticationSettings.ClientId,
                                        _authenticationSettings.ClientSecret, _authenticationSettings.RedirectUrl);

            HttpContent content = _client.BuildStringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _client.PostAsync(_authenticationSettings.ApiTokenUrl, content);

            var body = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(body);

            return Ok(body);
        }
    }
}
