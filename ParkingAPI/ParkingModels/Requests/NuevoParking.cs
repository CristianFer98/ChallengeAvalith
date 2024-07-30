using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingModels
{
    public class NuevoParking
    {
        public int IdAuto { get; set; }
        public int IdUsuario { get; set; }
        public int Duracion { get; set; }
        public string Direccion { get; set; }
    }
}
