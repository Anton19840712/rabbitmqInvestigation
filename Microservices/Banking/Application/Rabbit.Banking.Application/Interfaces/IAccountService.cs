using Rabbit.Banking.Domain.Models;

namespace Rabbit.Banking.Application.Interfaces;

public interface IAccountService
{
	IEnumerable<Account> GetAccounts();
}