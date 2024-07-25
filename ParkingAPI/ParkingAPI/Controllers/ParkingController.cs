using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingModels;
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
        [Route("Info")]
        public IActionResult GetInformation([FromBody] ParkingInfoRequest request)
        {
            ParkingInfoResponse parkingInfoResponse = new ParkingInfoResponse();

            try
            {
                Usuario usuario = _parkingService.GetUser(request);

                if (usuario != null)
                {
                    parkingInfoResponse.Autos = _parkingService.GetCarsByIdUser(request.UserId);
                    List<string> patentes = GetPatentes(parkingInfoResponse.Autos);
                    parkingInfoResponse.Parking = _parkingService.GetParkingByPatentes(patentes);

                    return Ok(parkingInfoResponse);
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

        private List<string> GetPatentes(List<Auto> autos)
        {
            List<string> patentes = new List<string>();

            foreach (var auto in autos)
            {
                patentes.Add(auto.Patente);
            }
            return patentes;
        }
    }
}
