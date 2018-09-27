using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using portal_2.API.Data;
using portal_2.API.Dtos;

namespace portal_2.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrokersController : ControllerBase
    {
        private readonly IPortalRepository _repo;
        private readonly IMapper _mapper;

        public BrokersController(IPortalRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrokers()
        {
            var brokers = await _repo.GetBrokers();

            var brokersToReturn = _mapper.Map<IEnumerable<BrokerForListDto>>(brokers);

            return Ok(brokersToReturn);
        }

        [HttpGet("{brokerid}")]
        public async Task<IActionResult> GetBroker(int brokerid)
        {
            var broker = await _repo.GetBroker(brokerid);

            var brokerToReturn = _mapper.Map<BrokerForDetailedDto>(broker);

            return Ok(brokerToReturn);
        }
    }
}