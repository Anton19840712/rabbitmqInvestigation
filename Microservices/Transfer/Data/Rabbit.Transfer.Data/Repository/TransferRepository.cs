using Rabbit.Transfer.Data.Context;
using Rabbit.Transfer.Domain.Interfaces;
using Rabbit.Transfer.Domain.Models;

namespace Rabbit.Transfer.Data.Repository;

public class TransferRepository : ITransferRepository
{
	private readonly TransferDbContext _ctx;
	public TransferRepository(TransferDbContext ctx)
	{
		_ctx = ctx;
	}
	public IEnumerable<TransferLog> GetTransferLogs()
	{
		var response = _ctx.TransferLogs.ToList();
		return response;
	}

	public async Task AddAsync(TransferLog transferLog)
	{
		_ctx.Add(transferLog);
		await _ctx.SaveChangesAsync();
	}
}