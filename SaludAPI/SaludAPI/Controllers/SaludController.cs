using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaludAPI.Models;
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

        public static List<Turno> turnos = new List<Turno>()
        {
            new Turno() { Id = 1, InstitucionSalud = "Centro Salud Favaloro", NumeroDeTramite = "123456", Fecha = new DateTime(2024, 7, 25, 14, 30, 0), Especialidad = "CARDIOLOGIA"},
            new Turno() { Id = 2, InstitucionSalud = "Centro Salud Favaloro", NumeroDeTramite =  "123456", Fecha = new DateTime(2024, 7, 25, 14, 30, 0), Especialidad = "NEUROLOGIA"},
            new Turno() { Id = 3, InstitucionSalud = "Centro OSDE", NumeroDeTramite = "654321", Fecha = new DateTime(2024, 7, 25, 14, 30, 0), Especialidad = "PEDIATRIA"},
            new Turno() { Id = 4, InstitucionSalud = "Centro PAMI", NumeroDeTramite = "654321", Fecha = new DateTime(2024, 7, 25, 14, 30, 0), Especialidad = "DERMATOLOGIA"},
            new Turno() { Id = 5, InstitucionSalud = "Hospital Militar", NumeroDeTramite = "999999", Fecha = new DateTime(2024, 7, 25, 14, 30, 0), Especialidad = "ODONTOLOGIA"}
        };

        [Authorize]
        [HttpPost("Info")]
        public IActionResult Info([FromBody] string NumeroDeTramite)
        {
            try
            {
                if (String.IsNullOrEmpty(NumeroDeTramite))
                {
                    return BadRequest("El número de trámite no puede estar vacío.");
                }

                var listaFiltrada = turnos.Where(t => t.NumeroDeTramite == NumeroDeTramite).ToList();
                return Ok(listaFiltrada);

            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
            }

        }

        [Authorize]
        [HttpPost("NuevoTurno")]
        public IActionResult NuevoTurno([FromBody] Turno turno)
        {
            try
            {
                int Id = turnos.Count() + 1;
                turno.Id = Id;
                turnos.Add(turno);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error");
            }

        }
    }
}
