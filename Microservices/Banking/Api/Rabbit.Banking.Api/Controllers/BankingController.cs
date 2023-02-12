using Microsoft.AspNetCore.Mvc;
using Rabbit.Banking.Application.Interfaces;
using Rabbit.Banking.Application.Models;
using Rabbit.Banking.Application.Services;
using Rabbit.Banking.Domain.Interfaces;

namespace Rabbit.Banking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankingController : ControllerBase
{
	private readonly ILogger<BankingController> _logger;
	private readonly IAccountService _accountService;

	public BankingController(ILogger<BankingController> logger, IAccountService accountService)
	{
		_accountService = accountService;
		_logger = logger;
	}

	[HttpGet("GetAccounts")]
	public ActionResult Get()
	{
		var response = _accountService.GetAccounts();

		return Ok(response);
	}

	[HttpPost]
	public IActionResult Post([FromBody] AccountTransfer accountTransfer)
	{
		_accountService.Transfer(accountTransfer);
		return Ok(accountTransfer);
	}
}