using System.Text;
using RabbitMQ.Client;

//var factory = new ConnectionFactory { HostName = "amqps://myhgmgcy:t2A20sj74kIddDIM9x52VkElgp29ISye@goose.rmq2.cloudamqp.com/myhgmgcy" };

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

const string message = "Hello World2!";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: string.Empty,
                     routingKey: "hello2",
                     basicProperties: null,
                     body: body);
Console.WriteLine($" [x] Sent {message}");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();