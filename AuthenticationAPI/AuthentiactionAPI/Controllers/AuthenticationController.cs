using Microsoft.AspNetCore.Mvc;
using Model;
using Service.interfaces;
using System;
using System.Linq;


namespace AuthenticationAPI.Controllers
{
    /// <summary>
    /// Servicio encargado de registrar nuevos usuarios y crear Token de acceso para las aplicaciones
    /// </summary>
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
            try
            {
                bool register = _registerService.Register(newUser);

                if (register)
                {
                    return Ok("Usuario registrado con exito.");
                }
                else
                {
                    return Conflict("Usuario Existente");
                }
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
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
