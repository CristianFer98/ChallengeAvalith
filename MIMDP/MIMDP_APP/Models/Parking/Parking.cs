namespace MIMDP_APP.Models.Parking
{
    public class Parking
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public Autos Auto { get; set; }
        public string Patente { get; set; }
        public decimal DuracionEnHoras { get; set; }

    }
}
