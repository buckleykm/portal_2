using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using portal_2.API.Data;
using portal_2.API.Dtos;
using portal_2.API.Models;

namespace portal_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(BrokerForRegisterDto brokerForRegisterDto)
        {
            // validate request

            brokerForRegisterDto.Username = brokerForRegisterDto.Username.ToLower();

            if (await _repo.BrokerExists(brokerForRegisterDto.Username))
                return BadRequest("Username already exists");

            var brokerToCreate = new Broker
            {
                Username = brokerForRegisterDto.Username
            };

            var createdBroker = await _repo.Register(brokerToCreate, brokerForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(BrokerForLoginDto brokerForLoginDto)
        {
            var brokerFromRepo = await _repo.Login(brokerForLoginDto.Username.ToLower(), brokerForLoginDto.Password);

            if (brokerFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, brokerFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, brokerFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}