using Microsoft.EntityFrameworkCore;
using SaludModels;
using SaludModels.Data;
using SaludRepository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaludRepository
{
    public class SaludRepository : ISaludRepository
    {

        private readonly SaludContext _saludContext;

        public SaludRepository(SaludContext saludContext)
        {
            _saludContext = saludContext;
        }
        public List<CentroDeSalud> GetCentrosDeSalud()
        {
            try
            {
                return _saludContext.CentroDeSalud.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Especialidad> GetEspecialidades()
        {
            try
            {
                return _saludContext.Especialidad.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Turnos> GetTurnosByUserId(int id)
        {
            try
            {
                List<Turnos> turnos = _saludContext.Turnos.Where(t => t.IdUsuario == id).
                    Include(t => t.IdCentroDeSaludNavigation).
                    Include(t => t.IdEspecialidadNavigation).
                    Include(t => t.IdUsuarioNavigation).ToList();
                return turnos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUserById(AccesRequest accesRequest)
        {
            return _saludContext.Usuario.Where(u => u.NumeroDeTramite == accesRequest.NumeroDeTramite &&
                                               u.Dni == accesRequest.DNI).SingleOrDefault();
        }

        public Usuario GetUsuarioByNumeroDeTramite(string numeroDeTramite)
        {
            return _saludContext.Usuario.Where(u => u.NumeroDeTramite == numeroDeTramite).SingleOrDefault();
        }

        public void NuevoTurno(Turnos turno)
        {
            try
            {
                _saludContext.Turnos.Add(turno);
                _saludContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
