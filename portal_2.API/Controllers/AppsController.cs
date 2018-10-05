using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using portal_2.API.Data;
using portal_2.API.Helpers;

namespace portal_2.API.Controllers
{
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

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetAppsForUser (int userid)
        {
            var apps = await _repo.GetAppsForUser(userid);

            return Ok(apps);
        }
    }
}