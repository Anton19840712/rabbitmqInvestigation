using Rabbit.Domain.Core.Commands;

namespace Rabbit.Banking.Domain.Commands;

public class TransferCommand : Command
{
	public int From { get; protected set; }
	public int To { get; protected set; }
	public decimal Amount { get; protected set; }
}