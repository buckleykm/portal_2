using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using portal_2.API.Data;
using portal_2.API.Dtos;
using portal_2.API.Helpers;

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
        public async Task<IActionResult> GetBrokers([FromQuery]BrokerParams brokerParams)
        {
            var brokers = await _repo.GetBrokers(brokerParams);

            var brokersToReturn = _mapper.Map<IEnumerable<BrokerForListDto>>(brokers);

            Response.AddPagination(brokers.CurrentPage, brokers.PageSize, brokers.TotalCount, brokers.TotalPages);

            return Ok(brokersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBroker(int id)
        {
            var broker = await _repo.GetBroker(id);

            var brokerToReturn = _mapper.Map<BrokerForDetailedDto>(broker);

            return Ok(brokerToReturn);
        }        
    }
}