using Rabbit.Banking.Application.Interfaces;
using Rabbit.Banking.Application.Models;
using Rabbit.Banking.Domain.Commands;
using Rabbit.Banking.Domain.Interfaces;
using Rabbit.Banking.Domain.Models;
using Rabbit.Domain.Core.Bus;

namespace Rabbit.Banking.Application.Services;

public class AccountService : IAccountService
{
	private readonly IAccountRepository _accountRepository;
	private readonly IEventBus _bus;
	public AccountService(IAccountRepository accountRepository, IEventBus bus)
	{
		_accountRepository = accountRepository;
		_bus = bus;
	}
	public IEnumerable<Account> GetAccounts()
	{
		return _accountRepository.GetAccounts();
	}

	public void Transfer(AccountTransfer accountTransfer)
	{
		var createTransferCommand = new CreateTransferCommand(
			accountTransfer.FromAccount,
			accountTransfer.ToAccount,
			accountTransfer.TransferAmount
		);

		_bus.SendCommand(createTransferCommand);
	}
}