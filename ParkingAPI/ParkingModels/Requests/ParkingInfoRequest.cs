namespace ParkingModels
{
    /// <summary>
    /// Es la información necesaria para traer la información de parking 
    /// proporcionada por quien consume la aplicación
    /// </summary>
    public class ParkingInfoRequest
    {
        public string Dni { get; set; }
        public int UserId { get; set; }
    }
}
