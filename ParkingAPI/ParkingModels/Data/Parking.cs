using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ParkingModels.Data
{
    public class Parking
    {
        public int Id { get; set; }
        public int IdAuto { get; set; }
        public int IdUsuario { get; set; }
        public string Direccion { get; set; }
        public int DuracionEnHoras { get; set; }

        public Autos Auto { get; set; }
        public Usuario Usuario { get; set; }
    }
}
