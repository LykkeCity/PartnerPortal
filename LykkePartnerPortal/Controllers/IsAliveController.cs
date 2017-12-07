using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using Core.Services;
using Swashbuckle.SwaggerGen.Annotations;

namespace LykkePartnerPortal.Controllers
{
    // NOTE: See https://lykkex.atlassian.net/wiki/spaces/LKEWALLET/pages/35755585/Add+your+app+to+Monitoring
    [Route("api/isAlive")]
    public class IsAliveController : Controller
    {
        private readonly IHealthService _healthService;

        public IsAliveController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        /// <summary>
        /// Checks service is alive
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation("IsAlive")]
        [ProducesResponseType(typeof(Models.IsAliveResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Models.ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            var healthViloationMessage = _healthService.GetHealthViolationMessage();
            if (healthViloationMessage != null)
            {
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new Models.ErrorResponse { ErrorMessage = $"Service is unhealthy: {healthViloationMessage}" });
            }

            // NOTE: Feel free to extend IsAliveResponse, to display job-specific indicators
            return Ok(new Models.IsAliveResponse
            {
                Name = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationName,
                Version = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationVersion,
                Env = Program.EnvInfo,
                //#$if DEBUG
                IsDebug = true,
                //#$else
                //$#$//IsDebug = false,
                //#$endif
                IssueIndicators = _healthService.GetHealthIssues()
                    .Select(i => new Models.IsAliveResponse.IssueIndicator
                    {
                        Type = i.Type,
                        Value = i.Value
                    })
            });
        }
    }
}
