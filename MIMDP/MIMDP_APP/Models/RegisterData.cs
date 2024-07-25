using System;
using System.ComponentModel.DataAnnotations;

public class RegisterData
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(50, ErrorMessage = "No puede superar los 50 carácteres")]
    [Display(Name = "Nombre")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El Dni es requerido")]
    public string Dni { get; set; }

    [Required(ErrorMessage = "El Email es requerido")]
    [EmailAddress(ErrorMessage = "Proporcione un Email valido")]
    [Display(Name = "Correo")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La Contraseña es requerida")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Debe tener al menos 8 caracteres y no más de 100 letras")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Debe contener al menos una mayuscula y un numero")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Debe tener al menos 8 caracteres y no más de 100 letras")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Debe contener al menos una mayuscula y un numero")]
    [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
    [Display(Name="Confirmar Password")]
    public string PasswordConfirm { get; set; }
}

