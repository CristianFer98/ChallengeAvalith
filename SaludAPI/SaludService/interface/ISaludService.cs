using SaludModels;
using SaludModels.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaludService
{
    public interface ISaludService
    {
        List<CentroDeSalud> GetCentrosDeSalud();
        List<Especialidad> GetEspecialidades();
        List<Turnos> GetTurnosByUserId(int id);
        Usuario GetUserById(AccesRequest accesRequest);
        void NuevoTurno(Turnos turno);
    }
}
