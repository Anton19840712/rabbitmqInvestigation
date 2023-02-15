using Rabbit.Transfer.Domain.Models;

namespace Rabbit.Transfer.Application.Interfaces;

public interface ITransferService
{
	IEnumerable<TransferLog> GetTransferLogs();
}