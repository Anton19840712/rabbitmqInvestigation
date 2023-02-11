using Rabbit.Banking.Data.Context;
using Rabbit.Banking.Domain.Interfaces;
using Rabbit.Banking.Domain.Models;

namespace Rabbit.Banking.Data.Repository;

public class AccountRepository : IAccountRepository
{
	private readonly BankingDbContext _ctx;
	public AccountRepository(BankingDbContext ctx)
	{
		_ctx = ctx;
	}
	public IEnumerable<Account> GetAccounts()
	{
		var response = _ctx.Accounts.ToList();
		return response;
	}
}