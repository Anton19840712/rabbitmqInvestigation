using Rabbit.Domain.Core.Events;

namespace Rabbit.Domain.Core.Commands;

public class Command : Message
{
	public DateTime Timestamp { get; protected set; }
	protected Command()
	{
		Timestamp = DateTime.Now;
	}
}