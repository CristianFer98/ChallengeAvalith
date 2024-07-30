using MIMDP_APP.Models.Parking.Requests;
using MIMDP_APP.Models.Parking.Response;
using System.Collections.Generic;

namespace MIMDP_APP.Models.Parking.ViewModels
{
    public class ParkingIndexViewModel
    {
        public List<Autos> Autos { get; set; }
        public List<Parking> Parkings { get; set; }
        public NuevoParking NuevoParking { get; set; }
    }
}
