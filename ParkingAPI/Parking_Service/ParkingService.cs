
using Microsoft.AspNetCore.Mvc;
using ParkingModels;
using ParkingModels.Data;
using ParkingRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingService
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkingRepository;

        public ParkingService(IParkingRepository parkingRepository)
        {
                _parkingRepository = parkingRepository;
        }
        public void AddParking(NuevoParking request)
        {
            try
            {
                _parkingRepository.AddParking(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Autos> GetCarsByIdUser(int userId)
        {
            try
            {
                return _parkingRepository.GetCars(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Parking> GetParkingByIdUser(int id)
        {
            try
            {
                return _parkingRepository.GetParkingsByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUser(string dni)
        {
            try
            {
                return _parkingRepository.GetUser(dni);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
