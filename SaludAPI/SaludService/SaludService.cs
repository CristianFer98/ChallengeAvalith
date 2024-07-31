using SaludModels;
using SaludModels.Data;
using SaludRepository.interfaces;
using System;
using System.Collections.Generic;

namespace SaludService
{
    public class SaludService : ISaludService
    {
        private readonly ISaludRepository _saludRepository;

        public SaludService(ISaludRepository saludRepository)
        {
                _saludRepository = saludRepository; 
        }

        public List<CentroDeSalud> GetCentrosDeSalud()
        {
            try
            {
                return _saludRepository.GetCentrosDeSalud();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Especialidad> GetEspecialidades()
        {
            try
            {
                return _saludRepository.GetEspecialidades();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Turnos> GetTurnosByUserId(int id)
        {
            try
            {
                return _saludRepository.GetTurnosByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        public Usuario GetUserById(AccesRequest accesRequest)
        {
            return _saludRepository.GetUserById(accesRequest);
        }

        public Usuario GetUsuarioByNumeroDeTramite(string numeroDeTramite)
        {
            return _saludRepository.GetUsuarioByNumeroDeTramite(numeroDeTramite);
        }

        public void NuevoTurno(Turnos turno)
        {
            try
            {
                _saludRepository.NuevoTurno(turno);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
