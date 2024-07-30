using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParkingModels;
using ParkingModels.Data;
using ParkingService;
using System.Collections.Generic;

namespace ParkingAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [Authorize]
        [Route("autos")]
        public IActionResult GetCars([FromBody] string Dni)
        {
            List<Autos> autos = new List<Autos>();
            try
            {
                Usuario usuario = _parkingService.GetUser(Dni);

                if (usuario != null)
                {
                    autos = _parkingService.GetCarsByIdUser(usuario.Id);
                    
                    return Ok(autos);
                }
                else
                {
                    return NotFound("El usuario no existe, favor de crear una cuenta");
                }

            }
            catch (System.Exception)
            {
                return NotFound("Ha ocurrido un error interno");
            }

        }

        [Authorize]
        [Route("parkings")]
        public IActionResult GetParkings([FromBody] string Dni)
        {
            List<Parking> parkings = new List<Parking>();
            try
            {
                Usuario usuario = _parkingService.GetUser(Dni);

                if (usuario != null)
                {
                    parkings = _parkingService.GetParkingByIdUser(usuario.Id);
                    return Ok(parkings);
                }
                else
                {
                    return NotFound("El usuario no existe, favor de crear una cuenta");
                }

            }
            catch (System.Exception)
            {
                return NotFound("Ha ocurrido un error interno");
            }

        }

        [Authorize]
        [Route("nuevo")]
        public IActionResult NuevoParking([FromBody] NuevoParking request)
        {
            try
            {
                _parkingService.AddParking(request);
                return Ok("Agregado con exito");
            }
            catch (System.Exception)
            {
                return BadRequest("Ha ingresado mal un dato");
            }

        }


      
    }
}
