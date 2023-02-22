using API.Commands;
using API.Queries;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> Orders()

        => await _mediator.Send(new GetOrdersQuery());

        [HttpPost("{id}")]
        public async Task<OrderDto> Order(int id)
            => await _mediator.Send(new GetOrderByIdQuery(id));

        [HttpGet("{filter}")]
        public async Task<IEnumerable<OrderDto>> OrdersFiltr(string filter)
          => await _mediator.Send(new GetOrdersByFilterQuery(filter));

        [HttpPost]
        public async Task<ActionResult> AddOrder(OrderDto orderDto)
        {
            await _mediator.Send(new AddOrderCommand(orderDto));
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder(OrderDto orderDto)
        {
            await _mediator.Send(new UpdateOrderCommand(orderDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return NoContent();
        }
    }
}
