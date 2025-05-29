namespace SafeZoneAPI.Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public string? Nivel { get; set; } // Leve, Moderado, Grave
        public string? Mensagem { get; set; }
        public DateTime DataEmissao { get; set; }

        public int RegiaoRiscoId { get; set; }
        public RegiaoRisco? RegiaoRisco { get; set; }
    }
}
