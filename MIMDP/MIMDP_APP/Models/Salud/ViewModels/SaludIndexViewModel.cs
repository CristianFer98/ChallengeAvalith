using System.Collections.Generic;

namespace MIMDP_APP.Models.Salud.ViewModels
{
    public class SaludIndexViewModel
    {
        public List<CentroDeSalud> CentrosDeSalud { get; set; }

        public List<Turnos> Turnos { get; set; }

        public List<Especialidad> Espacialidades { get; set; }

        public Turnos Turno { get; set; }

        public string NumeroDeTramite {get;set;}

        public int UserId { get; set; }

    }
}
