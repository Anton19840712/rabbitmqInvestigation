﻿using Rabbit.Domain.Core.Events;

namespace Rabbit.Banking.Domain.Events;

public class TransferCreatedEvent : Event
{
	public int FromAccount { get; private set; }
	public int ToAccount { get; private set; }
	public decimal Amount { get; private set; }

	public TransferCreatedEvent(int fromAccount, int toAccount, decimal amount)
	{
		FromAccount = fromAccount;
		ToAccount = toAccount;
		Amount = amount;
	}
}