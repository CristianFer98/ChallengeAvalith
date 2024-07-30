using MIMDP_APP.Models.Parking.Requests;
using MIMDP_APP.Models.Parking.Response;

namespace MIMDP_APP.Models.Parking.ViewModels
{
    public class ParkingInfoViewModel
    {
        public ParkingInfoResponse ParkingInfoResponse { get; set; }
        public NewParkingRequest NewParkingRequest { get; set; }
    }
}
