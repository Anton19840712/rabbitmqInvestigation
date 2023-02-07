using RabbitMQ.Client;
using System.Text;
using Console = System.Console;

namespace Rabbit.Producer;

public class Sender
{
	public static void Main(string[] args)
	{
		var factory = new ConnectionFactory() { HostName = "localhost" };

		using (var connection = factory.CreateConnection())

		//1 - channel:
		using (var channel = connection.CreateModel())
		{
			//2 - queue:
			channel.QueueDeclare("queueName", false, false, false, null);

			for (var i = 0; i < 30; i++)
			{
				//3 - message:
				var message = $"RabbitMQ message {i}";
				var body = Encoding.UTF8.GetBytes(message);

				//4 - publish body with message in channel:
				channel.BasicPublish("", "queueName", null, body);
				Console.WriteLine($"Message number {i} was successfully sent.");
			}
		}
		Console.ReadLine();
	}
}