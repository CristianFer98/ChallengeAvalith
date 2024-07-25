using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;

        public AuthenticationController(ILoginService loginService, IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterData newUser)
        {

            bool register = _registerService.Register(newUser);

            if (register)
            {
                return Ok("Usuario registrado con exito.");
            }
            else
            {
                return BadRequest("Usuario existente");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginData dataUser)
        {
            try
            {
                string Jwt = _loginService.Login(dataUser);

                if (Jwt.Any())
                {
                    return Ok(Jwt);
                }
                return Unauthorized("Usuario inexistente");
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
            }
            
        }


    }
}
