using MassTransit;
using MassTransitIntro.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MassTransitIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly ILogger<OrderController> _logger;
        readonly IRequestClient<SubmitOrder> _submitOrderRequestClient;

        public OrderController(ILogger<OrderController> logger, IRequestClient<SubmitOrder> submitOrderRequestClient)
        {
            _logger = logger;
            _submitOrderRequestClient = submitOrderRequestClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string customerNumber)
        {
            var response = await _submitOrderRequestClient.GetResponse<OrderSubmissionAccepted>(new
            {
                OrderId = id,
                InVar.Timestamp,
                CustomerNumber = customerNumber
            });

            return Ok(response.Message);

            //minutul 20:57
        }
    }
}
