using System.Collections.Generic;

namespace MIMDP_APP.Models.Parking.Requests
{
    public class ParkingInfoResponse
    {
        public List<Auto> Autos { get; set; }
        public List<Parking> Parking { get; set; }
    }
}
