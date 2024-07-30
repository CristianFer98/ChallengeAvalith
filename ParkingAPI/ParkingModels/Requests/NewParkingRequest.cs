using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingModels
{
    public class NewParkingRequest
    {
        public string Patente { get; set; }
        public int Duracion { get; set; }
        public string Direccion { get; set; }
    }
}
