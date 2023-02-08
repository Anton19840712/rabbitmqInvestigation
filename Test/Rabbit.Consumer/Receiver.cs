using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Console = System.Console;

namespace Rabbit.Consumer;

public class Receiver
{
	public static void Main(string[] args)
	{
		var factory = new ConnectionFactory() { HostName = "localhost" };

		using var connection = factory.CreateConnection();
		using var channel = connection.CreateModel();
		channel
			.QueueDeclare("queueName", false, false, false, null);

		var consumer = new EventingBasicConsumer(channel);
		consumer.Received += (model, basicDeliverEventArgs) =>
		{
			var body = basicDeliverEventArgs.Body.ToArray();
			var message = Encoding.UTF8.GetString(body);
			Console.WriteLine("Received Message is: {0}...", message);
		};
		channel.BasicConsume("queueName", true, consumer);
		Console.ReadLine();
	}
}