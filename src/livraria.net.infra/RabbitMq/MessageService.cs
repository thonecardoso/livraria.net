using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace livraria.net.infra.RabbitMq
{
    // define interface and service
    public interface IMessageService
    {
        Task<bool> Enqueue(string message);
    }

    public class MessageService : IMessageService
    {
        ConnectionFactory _factory;
        IConnection _conn;
        IModel _channel;
        public MessageService()
        {
            Console.WriteLine("about to connect to rabbit");

            _factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672 };
            _factory.UserName = "guest";
            _factory.Password = "guest";
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: "livraria.net.queue",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }
        public async Task<bool> Enqueue(string messageString)
        {
            var body = Encoding.UTF8.GetBytes("server processed " + messageString);
            _channel.BasicPublish(exchange: "",
                                routingKey: "livraria.net.queue",
                                basicProperties: null,
                                body: body);
            Console.WriteLine(" [x] Published {0} to RabbitMQ", messageString);
            return true;
        }
    }
}