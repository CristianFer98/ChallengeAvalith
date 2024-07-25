using ParkingModels;
using System.Collections.Generic;

namespace ParkingService
{
    /// <summary>
    /// Metodos que proporciona el servicio de parking. 
    /// </summary>
    public interface IParkingService
    {
        List<Auto> GetCarsByIdUser(int userId);
        List<Parking> GetParkingByPatentes(List<string> patentes);
        Usuario GetUser(ParkingInfoRequest request);
    }
}
