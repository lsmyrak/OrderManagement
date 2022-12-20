using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IOrderDetalisService
    {
        public Task Add(OrderDetalisDto orderDetalisDto);
        public Task<OrderDetalisDto> Get(int id);
        public Task<IEnumerable<OrderDetalisDto>> GetAll();
        public Task Delete(int id);
        public Task Update(OrderDetalisDto orderDetalisDto);
        public Task<IEnumerable<OrderDetalisDto>> GetBy(Expression<Func<OrderDetalis, bool>> predycate);
    }
}
