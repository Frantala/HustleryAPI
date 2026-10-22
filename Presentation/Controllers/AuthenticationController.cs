using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly IUserServices UserServices;
        public readonly IProductServices ProductServices;

        private readonly IUserRepository _userRepository;
        public AuthenticationController(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }


        [HttpPost("authenticate")]
        public ActionResult<string> Authentication([FromBody] CredentialAuthenticateDto credentials)
        {

            User? userAuthenticated = _userRepository.Authenticate(credentials.Name, credentials.Password);

            if(userAuthenticated is not null)
            {
                return Ok("llave token");
            }
            return Unauthorized();
        }
    }
}
