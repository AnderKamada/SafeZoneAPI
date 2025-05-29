namespace SafeZoneAPI.MLOperations
{
    public class RiscoInput
    {
        public string TipoRisco { get; set; } = string.Empty;
        public float UmidadeSolo { get; set; }
        public float NivelAgua { get; set; }
        public float Temperatura { get; set; }
    }
}
