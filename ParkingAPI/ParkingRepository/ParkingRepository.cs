using Microsoft.EntityFrameworkCore;
using ParkingModels;
using ParkingModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingRepository
{
    /// <summary>
    /// Define una lista estatica que almacena los Parqueos y los devuelve, simulando una base de datos.
    /// </summary>
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkingContext _parkingContext;

        public ParkingRepository(ParkingContext parkingContext)
        {
            _parkingContext = parkingContext;
        }

        public List<Autos> GetCars(int userId)
        {
            try
            {
                List<Autos> autos = _parkingContext.Autos.Where(a => a.IdUsuario == userId).ToList();

                return autos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Parking> GetParkingsByUserId(int userId)
        {
            try
            {
                List<Parking> parkings = _parkingContext.Parking.Where(p => p.IdUsuario == userId).Include(p => p.Auto).ToList();
                return parkings;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario GetUser(string dni)
        {
            try
            {
                return _parkingContext.Usuario.Where(u => u.DNI == dni).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddParking(NuevoParking request)
        {
            try
            {
                int idUser = GetUserByAutoId(request.IdAuto);

                Parking parking = new Parking();
                parking.IdAuto = request.IdAuto;
                parking.IdUsuario = idUser;
                parking.Direccion = request.Direccion;
                parking.DuracionEnHoras = request.Duracion;

                _parkingContext.Parking.Add(parking);
                _parkingContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int GetUserByAutoId(int idAuto)
        {
            try
            {
                Autos auto = _parkingContext.Autos.Where(a => a.Id == idAuto).SingleOrDefault();
                return auto.IdUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
