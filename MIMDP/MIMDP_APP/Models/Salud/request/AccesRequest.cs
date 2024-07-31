using System.ComponentModel.DataAnnotations;

namespace MIMDP_APP.Models.Salud.request
{
    public class AccesRequest
    {
        [Required(ErrorMessage = "El numero de tramite es requerido")]
        public string NumeroDeTramite { get; set; }
        public string DNI { get; set; }
    }
}
