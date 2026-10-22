using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {

        private readonly UserRepository _userRepository;
        public AuthenticatorController(UserRepository userRepository) 
        { 
        
        }


        [HttpPost]
        public IActionResult Authentication([FromBody] CredentialAuthenticateDto credentials)
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
