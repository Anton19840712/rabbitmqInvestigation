using Microsoft.Extensions.DependencyInjection;
using Rabbit.Domain.Core.Bus;
using Rabbit.Infrastructure.Bus;

namespace Rabbit.Infrastructure.Ioc;

public class DependencyContainer
{
	public static void RegisterServices(IServiceCollection services)
	{
		//Domain Bus
		services.AddTransient<IEventBus, RabbitMqBus>();
	}
}