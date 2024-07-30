using System;
using System.ComponentModel.DataAnnotations;

namespace MIMDP_APP.Models.Salud
{
    public class Turno
    {
        public int Id { get; set; }

        [Required]
        public string InstitucionSalud { get; set; }

        [Required]
        public string Especialidad { get; set; }

        public string NumeroDeTramite { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

    }
}
