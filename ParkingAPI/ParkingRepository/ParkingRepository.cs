using ParkingModels;
using System.Collections.Generic;

namespace ParkingRepository
{
    /// <summary>
    /// Define una lista estatica que almacena los Parqueos y los devuelve, simulando una base de datos.
    /// </summary>
    public class ParkingRepository
    {
 
        private static readonly List<Parking> parkings = new List<Parking>
        {
            new Parking { Id = 1, Patente = "ABC-123", Direccion = "Argentina 3393", DuracionEnHoras = 1.5m,},
            new Parking { Id = 2, Patente = "EFR-152", Direccion = "Indart 3562", DuracionEnHoras = 1.0m},
            new Parking { Id = 3, Patente = "MBN-856", Direccion = "America 25", DuracionEnHoras = 2.0m }
        };

        public static List<Parking> ObtenerParkings()
        {
            return parkings;
        }
    }
}
