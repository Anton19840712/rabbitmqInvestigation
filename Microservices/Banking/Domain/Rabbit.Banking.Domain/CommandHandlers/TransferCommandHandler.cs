using MediatR;
using Rabbit.Banking.Domain.Commands;
using Rabbit.Banking.Domain.Events;
using Rabbit.Domain.Core.Bus;

namespace Rabbit.Banking.Domain.CommandHandlers;

public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
{
	private readonly IEventBus _bus;

	public TransferCommandHandler(IEventBus bus)
	{
		_bus = bus;
	}
	public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
	{
		//publish event to RabbitMQ
		_bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

		return Task.FromResult(true);
	}
}