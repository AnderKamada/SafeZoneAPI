using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeZoneAPI.Models
{
    public class RegiaoRisco
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? TipoRisco { get; set; } // Ex: Enchente, Deslizamento, Calor Extremo
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonIgnore]
        public ICollection<Alerta>? Alertas { get; set; } // Relacionamento 1:N
    }
}
