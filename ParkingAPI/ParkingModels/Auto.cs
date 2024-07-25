using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingModels
{
    public class Auto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Patente { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}
