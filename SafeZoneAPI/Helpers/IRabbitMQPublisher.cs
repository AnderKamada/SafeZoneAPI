namespace SafeZoneAPI.Helpers
{
    public interface IRabbitMQPublisher
    {
        void PublicarMensagem(string mensagem);
    }
}