using System.Collections.Generic;

namespace MIMDP_APP.Models.Parking.Response
{
    public class ParkingInfoResponse
    {
        public List<Autos> Autos { get; set; }
        public List<Parking> Parking { get; set; }
    }
}
