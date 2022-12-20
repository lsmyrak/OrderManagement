using Domain.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<Order> Get(int id)
        {
            return await _context.Order.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Order.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task Insert(Order entity)
        {
            _context.Order.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = _context.Order.FirstOrDefault(x => x.Id == id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Order entity)
        {
            _context.Order.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetByFilter(Expression<Func<Order, bool>> predycate)
        {
            var orders = _context.Order.Where(x => x.IsDeleted == false);
            if (predycate != null)
            {
                orders = orders.Where(predycate);
            }
            return await orders.ToArrayAsync();
        }
    }
}
