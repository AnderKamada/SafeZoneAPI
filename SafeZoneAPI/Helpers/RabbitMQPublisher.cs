using RabbitMQ.Client;
using RabbitMQ.Client.Events; 
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SafeZoneAPI.Helpers
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        public void PublicarMensagem(string mensagem)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
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
            catch (Exception ex)
            {
                Console.WriteLine($"[RabbitMQ] Falha ao publicar: {ex.Message}");
                // Opcional: logue ou ignore o erro para seguir com o teste
            }
            
        }
    }
}