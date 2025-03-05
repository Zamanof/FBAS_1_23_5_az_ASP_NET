using ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs;
using ASP_NET_22._ToDo_WebApi_For_Unit_Test.HostedServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger _logger;
        private MessageQueue _messageQueue;

        public TransactionController(ILogger<TransactionController> logger, MessageQueue messageQueue)
        {
            _logger = logger;
            _messageQueue = messageQueue;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction(CreateTransactionRequest request)
        {
            _messageQueue.Enqueue(request);
            //await Task.Run(async () => {

            //    _logger.LogError("Transaction begin!!!");
            //    await Task.Delay(10000);
            //    _logger.LogError("Transaction end!!!");
            //});

            return Ok();
        }
    }
}
