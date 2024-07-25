
using Microsoft.AspNetCore.Mvc;
using ParkingModels;
using ParkingRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingService
{
    public class ParkingService : IParkingService
    {
        public List<Auto> GetCarsByIdUser(int userId)
        {
            try
            {
                return AutosRepository.ObtenerAutos().Where(u => u.IdUsuario == userId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Parking> GetParkingByPatentes(List<string> patentes)
        {
            try
            {
                return ParkingRepository.ParkingRepository.ObtenerParkings().Where(e => patentes.Contains(e.Patente)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUser(ParkingInfoRequest request)
        {
            try
            {
                return UsuariosRepository.ObtenerClientes().Where(u => u.Dni == request.Dni && u.Id == request.UserId).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
