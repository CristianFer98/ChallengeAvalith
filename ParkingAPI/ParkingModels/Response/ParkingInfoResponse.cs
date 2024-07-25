using System.Collections.Generic;

namespace ParkingModels
{
    /// <summary>
    /// Es el modelo de respuesta a la solicitud de inforación inicial del parking
    /// </summary>
    public class ParkingInfoResponse
    {
        public List<Auto> Autos { get; set; }
        public List<Parking> Parking { get; set; }

    }
}
