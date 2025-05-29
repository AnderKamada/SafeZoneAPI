namespace SafeZoneAPI.Models
{
    public class Abrigo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public int Capacidade { get; set; }
        public bool Disponivel { get; set; } = true;

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
