using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rabbit.Banking.Application.Interfaces;
using Rabbit.Banking.Application.Services;
using Rabbit.Banking.Data.Context;
using Rabbit.Banking.Data.Repository;
using Rabbit.Banking.Domain.CommandHandlers;
using Rabbit.Banking.Domain.Commands;
using Rabbit.Banking.Domain.Events;
using Rabbit.Banking.Domain.Interfaces;
using Rabbit.Domain.Core.Bus;
using Rabbit.Infrastructure.Bus;
using Rabbit.Transfer.Application.Interfaces;
using Rabbit.Transfer.Application.Services;
using Rabbit.Transfer.Data.Context;
using Rabbit.Transfer.Data.Repository;
using Rabbit.Transfer.Domain.EventHandlers;
using Rabbit.Transfer.Domain.Interfaces;
using TransferCreatedEvent = Rabbit.Transfer.Domain.Events.TransferCreatedEvent;

namespace Rabbit.Infrastructure.Ioc;

public class DependencyContainer
{
	public static void RegisterServices(IServiceCollection services)
	{
		//Domain Bus
		services.AddSingleton<IEventBus, RabbitMqBus>(sp =>
		{
			var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
			return new RabbitMqBus(sp.GetService<IMediator>() ?? throw new InvalidOperationException(), scopeFactory);
		});

		//Subscriptions
		services.AddTransient<TransferEventHandler>();

		//Domain Events
		services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

		//Domain Banking Commands
		services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

		//Application Services 
		services.AddTransient<IAccountService, AccountService>();
		services.AddTransient<ITransferService, TransferService>();

		//Data
		services.AddTransient<IAccountRepository, AccountRepository>();
		services.AddTransient<ITransferRepository, TransferRepository>();
		services.AddTransient<BankingDbContext>();
		services.AddTransient<TransferDbContext>();
	}
}