using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service1.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginInfo user)
        {
            
            var token = _authenticationService.login(user.userName, user.password);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
        
    }

    public class LoginInfo
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}