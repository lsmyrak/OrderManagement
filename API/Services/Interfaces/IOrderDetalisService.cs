using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IOrderDetalisService
    {
        public Task Add(OrderDetalisDto orderDetalisDto, CancellationToken cancellationToken);
        public Task<OrderDetalisDto> Get(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<OrderDetalisDto>> GetAll(CancellationToken cancellationToken);
        public Task Delete(int id, CancellationToken cancellationToken);
        public Task Update(OrderDetalisDto orderDetalisDto, CancellationToken cancellationToken);
        public Task<IEnumerable<OrderDetalisDto>> GetBy(Expression<Func<OrderDetalis, bool>> predycate, CancellationToken cancellationToken);
        public Task<IEnumerable<OrderDetalisDto>> GetByFilter(string filter, CancellationToken cancellationToken);
    }
}
