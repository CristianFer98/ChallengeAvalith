using ParkingModels;
using ParkingModels.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingRepository
{
    public interface IParkingRepository
    {
        void AddParking(NuevoParking request);
        List<Autos> GetCars(int userId);
        List<Parking> GetParkingsByUserId(int userId);
        Usuario GetUser(string dni);
    }
}
