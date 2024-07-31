using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MIMDP_APP.Models.Salud
{
    public partial class Turnos
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El centro de Salud es requerido")]
        public int IdCentroDeSalud { get; set; }

        [Required(ErrorMessage = "La especialidad es requerida")]
        public int IdEspecialidad { get; set; }

        [FutureDate(ErrorMessage = "La fecha debe ser un día futuro.")]
        public string Horario { get; set; }

        public virtual CentroDeSalud IdCentroDeSaludNavigation { get; set; }
        public virtual Especialidad IdEspecialidadNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
