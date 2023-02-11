using Rabbit.Banking.Application.Interfaces;
using Rabbit.Banking.Domain.Interfaces;
using Rabbit.Banking.Domain.Models;

namespace Rabbit.Banking.Application.Services;

public class AccountService : IAccountService
{
	private readonly IAccountRepository _accountRepository;
	public AccountService(IAccountRepository accountRepository)
	{
		_accountRepository = accountRepository;
	}
	public IEnumerable<Account> GetAccounts()
	{
		return _accountRepository.GetAccounts();
	}
}