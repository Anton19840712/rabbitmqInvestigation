using Microsoft.AspNetCore.Mvc;
using Rabbit.Transfer.Application.Interfaces;
using Rabbit.Transfer.Domain.Models;

namespace Rabbit.Transfer.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TransferController : ControllerBase
	{
		private readonly ITransferService _transferService;

		public TransferController(ITransferService transferService)
		{
			_transferService = transferService;
		}
	
		[HttpGet]
		public ActionResult<IEnumerable<TransferLog>> Get()
		{
			return Ok(_transferService.GetTransferLogs());
		}
	}
}