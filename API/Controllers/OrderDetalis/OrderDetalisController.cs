using API.Commands;
using API.Queries;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.OrderDetalis
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetalisController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrderDetalisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDetalisDto>> OrdersDetalis()

       => await _mediator.Send(new GetOrderDetalisQuery());

        [HttpPost("{id}")]
        public async Task<OrderDetalisDto> OrderDetais(int id)
            => await _mediator.Send(new GetOrderDetalisByIdQuery(id));

        [HttpGet("filtr/{filtr}")]
        public async Task<IEnumerable<OrderDetalisDto>> OrdersDetalisFiltr(string filtr)
          => await _mediator.Send(new GetOrderDetalisByFilterQuery(filtr));

        [HttpPost]
        public async Task<ActionResult> AddOrderDetalis(OrderDetalisDto orderDetalisDto)
        {
            await _mediator.Send(new AddOrderDetalisCommand(orderDetalisDto));
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrderDetalis(OrderDetalisDto orderDetalisDto)
        {
            await _mediator.Send(new UpdateOrderDetalisCommand(orderDetalisDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderDetalis(int id)
        {
            await _mediator.Send(new DeleteOrderDetalisCommand(id));
            return NoContent();
        }
    }
}
