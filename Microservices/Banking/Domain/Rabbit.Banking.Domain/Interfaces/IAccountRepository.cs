using Rabbit.Banking.Domain.Models;

namespace Rabbit.Banking.Domain.Interfaces;

public interface IAccountRepository
{
	IEnumerable<Account> GetAccounts();
}