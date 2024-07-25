using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Data
{
    public partial class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Email { get; set; }
        [Required]
        [StringLength(256)]
        public string Contraseña { get; set; }
        [Required]
        [Column("DNI")]
        [StringLength(8)]
        public string Dni { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
