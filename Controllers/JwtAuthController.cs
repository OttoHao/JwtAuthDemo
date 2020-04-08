using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthDemo.Models;
using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JwtAuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtAuthService;

        public JwtAuthController(IJwtAuthService jwtAuthService)
        {
            _jwtAuthService = jwtAuthService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _jwtAuthService.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}