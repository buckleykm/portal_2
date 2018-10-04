using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using portal_2.API.Data;
using portal_2.API.Helpers;

namespace portal_2.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppsController : ControllerBase
    {
        private readonly IPortalRepository _repo;
        public AppsController(IPortalRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetApps()
        {
            var apps = await _repo.GetApps();

            return Ok(apps);
        }

        [HttpGet("{brokerid}")]
        public async Task<IActionResult> GetAppsForBroker (int brokerid)
        {
            var apps = await _repo.GetAppsForBroker(brokerid);

            return Ok(apps);
        }
    }
}