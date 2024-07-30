using System;

namespace SaludAPI.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string InstitucionSalud { get; set; }
        public string NumeroDeTramite { get; set; }
        public string Especialidad { get; set; }

        public DateTime Fecha { get; set; }

    }
}
