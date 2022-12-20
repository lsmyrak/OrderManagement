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
    public class ContractorRepository : IRepository<Contractor>
    {
        private readonly OrderContext _context;
        public ContractorRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var contractor = await _context.Contractor.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (contractor != null)
            {
                _context.Contractor.Remove(contractor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Contractor> Get(int id)
        {
            var contractor = await _context.Contractor.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (contractor == null)
            {
                return new Contractor();
            }
            return contractor;

        }

        public async Task<IEnumerable<Contractor>> GetAll()
        {
            return await _context.Contractor.Where(x => x.IsDeleted == false).ToArrayAsync();
        }

        public async Task<IEnumerable<Contractor>> GetByFilter(Expression<Func<Contractor, bool>> predycate)
        {
            var contractors = _context.Contractor.Where(x => x.IsDeleted == false);

            if (predycate != null)
            {
                contractors = contractors.Where(predycate);
            }
            return await contractors.ToListAsync();
        }

        public async Task Insert(Contractor entity)
        {
            _context.Contractor.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Contractor entity)
        {
            _context.Contractor.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
