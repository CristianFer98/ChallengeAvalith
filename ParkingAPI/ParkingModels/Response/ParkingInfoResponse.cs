using ParkingModels.Data;
using System.Collections.Generic;

namespace ParkingModels.Response
{
    /// <summary>
    /// Es el modelo de respuesta a la solicitud de inforación inicial del parking
    /// </summary>
    public class ParkingInfoResponse
    {
        public List<Autos> Autos { get; set; }
        public List<Parking> Parking { get; set; }

    }
}
