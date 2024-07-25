using ParkingModels;
using System;
using System.Collections.Generic;

namespace ParkingRepository
{
    /// <summary>
    /// Define una lista estatica que almacena los Autos y los devuelve, simulando una base de datos.
    /// </summary>
    public static class AutosRepository
    {

        private static readonly List<Auto> autos = new List<Auto>
        {
            new Auto { Id = 1, IdUsuario = 1, Patente = "ABC-123", Marca = "Chevrolet", Modelo = "Classic" },
            new Auto { Id = 2, IdUsuario = 1, Patente = "EFR-152", Marca = "Fiat", Modelo = "Uno" },
            new Auto { Id = 3, IdUsuario = 2, Patente = "MBN-856", Marca = "Renault", Modelo = "Logan" }
        };

        public static List<Auto> ObtenerAutos()
        {
            return autos;
        }
    }
}
