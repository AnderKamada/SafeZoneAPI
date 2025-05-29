using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeZoneAPI.Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public string? Nivel { get; set; } // Leve, Moderado, Grave
        public string? Mensagem { get; set; }
        public DateTime DataEmissao { get; set; }

        public int RegiaoRiscoId { get; set; }

        [JsonIgnore]
        public RegiaoRisco? RegiaoRisco { get; set; }
    }
}
