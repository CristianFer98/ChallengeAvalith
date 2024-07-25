using System;
using System.ComponentModel.DataAnnotations;

namespace MyAppMVC.Models
{
    public class LoginData
    {
        [Required(ErrorMessage = "El Email es requerido")]
        [EmailAddress(ErrorMessage = "Proporcione un Email valido")]
        [Display(Name ="Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La Contrasña es requerida")]
        public string Password { get; set; }
    }
}
