using API.Services;
using Contracts.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {

    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        private IOrderService _orderService;
        public GetOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var list = new List<OrderDto>();
            try
            {
                return await _orderService.GetAll();
            }
            catch
            {

            }
            finally
            {
                
            }
            return list;
        }
    }

}
