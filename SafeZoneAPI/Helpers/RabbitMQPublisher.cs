using RabbitMQ.Client;
using RabbitMQ.Client.Events; 
using System.Text;


namespace SafeZoneAPI.Helpers
{
    public class RabbitMQPublisher
    {
        public void PublicarMensagem(string mensagem)
        {
            var factory = new RabbitMQ.Client.ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "alertas",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(mensagem);
            channel.BasicPublish(exchange: "",
                                 routingKey: "alertas",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
