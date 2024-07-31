using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaludModels;
using SaludModels.Data;
using SaludService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaludAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SaludController : ControllerBase
    {
        private readonly ISaludService _saludService;

        public SaludController(ISaludService saludService)
        {
            _saludService = saludService;
        }

        [Authorize]
        [HttpGet("CentrosSalud")]
        public IActionResult GetCentroDeSalud()
        {
            try
            {
                List<CentroDeSalud> listaFiltrada = _saludService.GetCentrosDeSalud();
                return Ok(listaFiltrada);
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
            }
        }

        [Authorize]
        [HttpGet("Especialidades")]
        public IActionResult GetEspecialidades()
        {
            try
            {
                List<Especialidad> listaFiltrada = _saludService.GetEspecialidades();
                return Ok(listaFiltrada);
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
            }
        }

        [Authorize]
        [HttpPost("Usuario")]
        public IActionResult GetUsuario([FromBody] string numeroDeTramite)
        {
            try
            {
                Usuario usuario = _saludService.GetUsuarioByNumeroDeTramite(numeroDeTramite);
                return Ok(usuario);
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
            }
        }


        [Authorize]
        [HttpPost("Turnos")]
        public IActionResult GetTurnos([FromBody] AccesRequest accesRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(accesRequest.NumeroDeTramite))
                {
                    return BadRequest("El número de trámite no puede estar vacío.");
                }

                //Viaja el DNI y el numero de tramite. Deben concordar. 
                Usuario usuarioEsperado = _saludService.GetUserById(accesRequest);

                if (usuarioEsperado != null)
                {
                    List<Turnos> listaFiltrada = _saludService.GetTurnosByUserId(usuarioEsperado.Id);                   
                    return Ok(listaFiltrada);
                }
                else
                {
                    return NotFound("El Numero de Tramite no concuerda con el usuario logueado");
                }
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
            }
        }

        [Authorize]
        [HttpPost("NuevoTurno")]
        public IActionResult NuevoTurno([FromBody] Turnos turno)
        {
            try
            {
                _saludService.NuevoTurno(turno);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
            }

        }
    }
}
