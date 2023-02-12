using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rabbit.Banking.Application.Interfaces;
using Rabbit.Banking.Application.Services;
using Rabbit.Banking.Data.Context;
using Rabbit.Banking.Data.Repository;
using Rabbit.Banking.Domain.CommandHandlers;
using Rabbit.Banking.Domain.Commands;
using Rabbit.Banking.Domain.Interfaces;
using Rabbit.Domain.Core.Bus;
using Rabbit.Infrastructure.Bus;

namespace Rabbit.Infrastructure.Ioc;

public class DependencyContainer
{
	public static void RegisterServices(IServiceCollection services)
	{
		//Domain Bus
		services.AddTransient<IEventBus, RabbitMqBus>();

		//Domain banking commands
		services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

		//Application Services 
		services.AddTransient<IAccountService, AccountService>();

		//Data
		services.AddTransient<IAccountRepository, AccountRepository>();
		services.AddTransient<BankingDbContext>();
	}
}