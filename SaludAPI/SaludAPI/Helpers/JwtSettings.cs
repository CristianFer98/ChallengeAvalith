using System;

namespace SaludAPI
{
    /// <summary>
    /// Clase que define las propiedades de configuración del JWT
    /// </summary>
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
