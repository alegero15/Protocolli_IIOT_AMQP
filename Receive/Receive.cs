using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

internal class Receive
{
    private static void Main(string[] args)
    {
        ConnectionFactory factory = new ConnectionFactory();
        factory.HostName = "goose.rmq2.cloudamqp.com";
        factory.UserName = "myhgmgcy";
        factory.Password = "t2A20sj74kIddDIM9x52VkElgp29ISye";
        factory.VirtualHost = "myhgmgcy";
        factory.Port = 5672;

        using var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "hello2",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
        };
        channel.BasicConsume(queue: "hello2",
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}