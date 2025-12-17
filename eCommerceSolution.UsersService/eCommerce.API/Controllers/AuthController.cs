using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")] // api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPost("register")] // api/auth/register
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Bad register request");
            }
            var authResponse=await _usersService.Register(registerRequest);
            if (authResponse == null || authResponse.Success==false)
            {
                return BadRequest(authResponse);
            }
            return Ok(authResponse);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest) 
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid Login request data");
            }
            var authResponse = await _usersService.Login(loginRequest);
            if(authResponse == null || authResponse.Success==false) 
            {
                return Unauthorized(authResponse); 
            }
            return Ok(authResponse);

        }
    }
}
