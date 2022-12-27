using API.Services.Interfaces;
using Autofac.Core;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.Order
{
    public class UpdateOrderCommand:IRequest<int>
    {
        public OrderDto orderDto;
        public UpdateOrderCommand(OrderDto model)
        {
            orderDto = model;
        }

    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand,int>
    { 
        private readonly IOrderService _orderService;
  
        public UpdateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {            
            await _orderService.Update(request.orderDto,cancellationToken);
            return 0;            
        }
    }
}
