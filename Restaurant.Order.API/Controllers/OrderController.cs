using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Order.Application.Commands;
using Restaurant.Order.Application.Services.Interfaces;

namespace Restaurant.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommand command)
        {
            var response = await _orderService.Add(command);

            if (response.Invalid)
                return BadRequest(response.Notifications);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _orderService.GetAll();

            return Ok(response);
        }
    }
}
