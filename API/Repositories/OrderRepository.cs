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
    public class OrderRepository : IRepository<Order>
    {
        private readonly OrderContext _context;
        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task<Order> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Order.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Order.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task Insert(Order entity,CancellationToken cancellationToken)
        {
            _context.Order.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id,CancellationToken cancellationToken)
        {
            var order = _context.Order.FirstOrDefault(x => x.Id == id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Order entity,CancellationToken cancellationToken)
        {
            _context.Order.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByFilter(Expression<Func<Order, bool>> predycate,CancellationToken cancellationToken)
        {
            var orders = _context.Order.Where(x => x.IsDeleted == false);
            if (predycate != null)
            {
                orders = orders.Where(predycate);
            }
            return await orders.ToArrayAsync(cancellationToken);
        }
    }
}
