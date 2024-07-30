using ParkingModels;
using ParkingModels.Data;
using System.Collections.Generic;

namespace ParkingService
{
    /// <summary>
    /// Metodos que proporciona el servicio de parking. 
    /// </summary>
    public interface IParkingService
    {
        void AddParking(NuevoParking request);
        List<Autos> GetCarsByIdUser(int userId);
        List<Parking> GetParkingByIdUser(int userId);
        Usuario GetUser(string dni);
    }
}
