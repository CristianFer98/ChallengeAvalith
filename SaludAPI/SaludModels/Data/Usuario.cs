﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaludModels.Data
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NumeroDeTramite { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
    }
}
