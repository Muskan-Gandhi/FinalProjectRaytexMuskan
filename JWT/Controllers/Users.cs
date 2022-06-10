using JWT.Models;
using JWT.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jwtManager;

        public UsersController(IJWTManagerRepository jWTManager)
        {
            _jwtManager = jWTManager;
        }
        
        


        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users userdata)
        {
            var token =_jwtManager.Authenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
