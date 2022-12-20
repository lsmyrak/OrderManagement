using Domain.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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

        public async Task Delete(int id)
        {
            var orderDetalis = await _context.OrderDetalis.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (orderDetalis != null)
            {
                _context.OrderDetalis.Remove(orderDetalis);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<OrderDetalis> Get(int id)
        {
            return await _context.OrderDetalis.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<IEnumerable<OrderDetalis>> GetAll()
        {
            return await _context.OrderDetalis.Where(x => x.IsDeleted == false).ToArrayAsync();
        }

        public async Task<IEnumerable<OrderDetalis>> GetByFilter(Expression<Func<OrderDetalis, bool>> predycate)
        {
            var orderdetalisList = _context.OrderDetalis.Where(x => x.IsDeleted == false);
            if (predycate != null)
            {
                orderdetalisList = orderdetalisList.Where(predycate);
            }
            return await orderdetalisList.ToArrayAsync();
        }

        public async Task Insert(OrderDetalis entity)
        {
            _context.OrderDetalis.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(OrderDetalis entity)
        {
            _context.OrderDetalis.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
