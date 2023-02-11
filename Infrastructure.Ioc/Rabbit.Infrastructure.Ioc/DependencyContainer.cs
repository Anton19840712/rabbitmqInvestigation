using Microsoft.Extensions.DependencyInjection;
using Rabbit.Banking.Application.Interfaces;
using Rabbit.Banking.Application.Services;
using Rabbit.Banking.Data.Context;
using Rabbit.Banking.Data.Repository;
using Rabbit.Banking.Domain.Interfaces;
using Rabbit.Domain.Core.Bus;
using Rabbit.Infrastructure.Bus;

namespace Rabbit.Infrastructure.Ioc;

public class DependencyContainer
{
	public static void RegisterServices(IServiceCollection services)
	{
		//Domain Bus

		//services.AddSingleton<IMediator>();
		
		services.AddTransient<IEventBus, RabbitMqBus>();

		//Application Services 
		services.AddTransient<IAccountService, AccountService>();

		//Data
		services.AddTransient<IAccountRepository, AccountRepository>();
		services.AddTransient<BankingDbContext>();
	}
}