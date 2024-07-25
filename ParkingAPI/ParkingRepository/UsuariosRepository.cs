using ParkingModels;
using System.Collections.Generic;

namespace ParkingRepository
{
    /// <summary>
    /// Define una lista estatica que almacena los usuarios y los devuelve, simulando una base de datos.
    /// </summary>
    public class UsuariosRepository
    {

        private static readonly List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nombre = "Cristian Fernandez", Dni = "41139455"},
            new Usuario { Id = 2, Nombre = "Lara Aylen Acosta", Dni = "44413552" }
        };

        public static List<Usuario> ObtenerClientes()
        {
            return usuarios;
        }

    }
}
