using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaludModels.Data
{
    public partial class Turnos
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCentroDeSalud { get; set; }
        public int IdEspecialidad { get; set; }
        public string Horario { get; set; }

        public virtual CentroDeSalud IdCentroDeSaludNavigation { get; set; }
        public virtual Especialidad IdEspecialidadNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
