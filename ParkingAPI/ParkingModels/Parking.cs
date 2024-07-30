using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingModels
{
    public class Parking
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Patente { get; set; }
        public int DuracionEnHoras { get; set; }
    }
}
