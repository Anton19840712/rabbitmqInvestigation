using Microsoft.EntityFrameworkCore;
using Rabbit.Transfer.Domain.Models;

namespace Rabbit.Transfer.Data.Context;

public class TransferDbContext : DbContext
{
	public TransferDbContext(DbContextOptions options) : base(options) { }
	public DbSet<TransferLog> TransferLogs { get; set; }
}