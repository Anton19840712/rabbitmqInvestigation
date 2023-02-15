using Rabbit.Domain.Core.Bus;
using Rabbit.Transfer.Domain.Events;
using Rabbit.Transfer.Domain.Interfaces;
using Rabbit.Transfer.Domain.Models;

namespace Rabbit.Transfer.Domain.EventHandlers;

public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
{
	private readonly ITransferRepository _transferRepository;
	public TransferEventHandler(ITransferRepository transferRepository)
	{
		_transferRepository = transferRepository;
	}
	public async Task Handle(TransferCreatedEvent @event)
	{
		await _transferRepository.AddAsync(new TransferLog()
		{
			FromAccount = @event.From,
			ToAccount = @event.To,
			TransferAmount = @event.Amount
		});
	}
}