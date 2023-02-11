using Microsoft.EntityFrameworkCore;
using Rabbit.Banking.Domain.Models;

namespace Rabbit.Banking.Data.Context;

public class BankingDbContext : DbContext
{
	public BankingDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<Account> Accounts { get; set; }
}