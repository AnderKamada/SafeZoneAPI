namespace SafeZoneAPI.MLOperations
{
    public class RiscoPredictor
    {
        public RiscoOutput Prever(RiscoInput input)
        {
            // Simulação baseada em lógica simples
            var risco = "Baixo";
            float score = 0.2f;

            if (input.UmidadeSolo > 70 || input.NivelAgua > 80 || input.Temperatura > 38)
            {
                risco = "Alto";
                score = 0.9f;
            }
            else if (input.UmidadeSolo > 40 || input.NivelAgua > 50)
            {
                risco = "Médio";
                score = 0.6f;
            }

            return new RiscoOutput
            {
                Predicao = risco,
                Score = score
            };
        }
    }
}
