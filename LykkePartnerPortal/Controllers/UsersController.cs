using Common.Log;
using LykkePartnerPortal.Models.Users;
using LykkePartnerPortal.Settings;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System;
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

        public UsersController(ILog log, AuthenticationSettings authenticationSettings)
        {
            _log = log;
            _authenticationSettings = authenticationSettings;
        }

        /// <summary>
        /// Single sign on authentication
        /// </summary>
        [HttpPost]
        [SwaggerOperation("GetProducts")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Authentication([FromBody] SingleSignOnRequestModel model)
        {
            String postData = "code=" + model.Code;
            postData += "&client_id=" + _authenticationSettings.ClientId;
            postData += "&client_secret=" + _authenticationSettings.ClientSecret;
            postData += "&grant_type=" + "authorization_code";
            postData += "&redirect_uri=" + _authenticationSettings.RedirectUrl;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(_authenticationSettings.ApiTokenUrl,
                                 new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded"));

                var body = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest(body);

                return Ok(body);
            }
        }
    }
}
