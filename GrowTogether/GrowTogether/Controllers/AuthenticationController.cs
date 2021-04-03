using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowTogether.Models;
using GrowTogether.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrowTogether.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthService _authenticateService;

        public AuthenticationController(IAuthService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        //[Route("Login")]
        [HttpPost("Login")]
        public IActionResult Post([FromBody]User model)
        {
            var user = _authenticateService.Authenticate(model.UserName,model.Password);
            if (user == null)
                return BadRequest(new { message =  "Username or password is invalid" });
            return Ok(user);
        }
        // [Route("Register")]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] User model)
        {
            var user = _authenticateService.RegisterUser(model.UserName,model.Password,model.FirstName,model.LastName,model.ConfirmPassword,model.Avtar);
            if (user == null)
                return BadRequest(new { message = "Somehing went wrong while registring " });
            else
                return Ok(user);
        }
    }
}
