using System.ComponentModel.DataAnnotations.Schema;

namespace Rabbit.Banking.Domain.Models;

public class Account
{
	public int Id { get; set; }
	public string AccountType { get; set; }
	[Column(TypeName = "decimal(18,4)")]
	public decimal AccountBalance { get; set; }

}