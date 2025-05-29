using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Console = System.Console;
public class RabbitMQConsumer
{
    public void Consumir()
    {
        var factory = new RabbitMQ.Client.ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "alertas",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"[CONSUMIDOR] Mensagem recebida: {message}");
        };

        channel.BasicConsume(queue: "alertas",
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine("Consumidor pronto. Pressione qualquer tecla para sair...");
        Console.ReadLine();
    }
}
