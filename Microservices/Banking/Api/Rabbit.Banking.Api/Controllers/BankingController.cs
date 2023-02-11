using Microsoft.AspNetCore.Mvc;
using Rabbit.Banking.Domain.Interfaces;

namespace Rabbit.Banking.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BankingController : ControllerBase
	{
		private readonly ILogger<BankingController> _logger;
		private readonly IAccountRepository _accountRepository;

		public BankingController(ILogger<BankingController> logger, IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
			_logger = logger;
		}

		[HttpGet("GetAccounts")]
		public ActionResult Get()
		{
			var response = _accountRepository.GetAccounts();

			return Ok(response);
		}
	}
}