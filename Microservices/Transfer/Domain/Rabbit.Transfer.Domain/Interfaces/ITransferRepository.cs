using Rabbit.Transfer.Domain.Models;

namespace Rabbit.Transfer.Domain.Interfaces;

public interface ITransferRepository
{
	IEnumerable<TransferLog> GetTransferLogs();
	Task AddAsync(TransferLog transferLog);
}