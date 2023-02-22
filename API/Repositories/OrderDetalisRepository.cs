using Domain.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class OrderDetalisRepository : IRepository<OrderDetalis>
    {
        private readonly OrderContext _context;
        public OrderDetalisRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var orderDetalis = await _context.OrderDetalis.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (orderDetalis != null)
            {
                _context.OrderDetalis.Remove(orderDetalis);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<OrderDetalis> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.OrderDetalis.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false, cancellationToken);
        }

        public async Task<IEnumerable<OrderDetalis>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.OrderDetalis.Where(x => x.IsDeleted == false).ToArrayAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderDetalis>> GetBy(Expression<Func<OrderDetalis, bool>> predycate, CancellationToken cancellationToken)
        {
            var orderdetalisList = _context.OrderDetalis.Where(x => x.IsDeleted == false);
            if (predycate != null)
            {
                orderdetalisList = orderdetalisList.Where(predycate);
            }
            return await orderdetalisList.ToArrayAsync(cancellationToken);
        }

        public async Task Insert(OrderDetalis entity, CancellationToken cancellationToken)
        {
            _context.OrderDetalis.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(OrderDetalis entity, CancellationToken cancellationToken)
        {
            _context.OrderDetalis.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
