using System;
using System.ComponentModel.DataAnnotations;

namespace MIMDP_APP.Models.Parking.Requests
{
    public class NewParkingRequest
    {
        [Required]
        [MaxLength(10)]
        public string Patente { get; set; }

        [Required]
        [RegularExpression("^[1-5]$", ErrorMessage = "Solo se permiten los números del 1 al 5.")]
        public int Duracion { get; set; }

        [Required]
        [MaxLength(300)] 
        public string Direccion { get; set; }
    }
}
