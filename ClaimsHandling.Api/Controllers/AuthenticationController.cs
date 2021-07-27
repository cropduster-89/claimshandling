using ClaimsHandling.Domain;
using ClaimsHandling.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsHandling.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private const string UserNotFoundMessage = "Your login attempt was unsuccessful";

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult TryLogin([FromBody]Login login)
        {
            try
            {
                if (_userService.TryLogin(login))
                {
                    return NoContent();
                }

                return NotFound(UserNotFoundMessage); 
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
