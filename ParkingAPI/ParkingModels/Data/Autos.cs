using System;
using System.Collections.Generic;

namespace ParkingModels.Data
{
    public class Autos
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Patente { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public Usuario Usuario { get; set; }
    }
}
