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
    public class ContractorRepository : IRepository<Contractor>
    {
        private readonly OrderContext _context;
        public ContractorRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var contractor = await _context.Contractor.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (contractor != null)
            {
                _context.Contractor.Remove(contractor);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<Contractor> Get(int id, CancellationToken cancellationToken)
        {
            var contractor = await _context.Contractor.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false,cancellationToken);
            if (contractor == null)
            {
                return new Contractor();
            }
            return contractor;
        }

        public async Task<IEnumerable<Contractor>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Contractor.Where(x => x.IsDeleted == false).ToArrayAsync(cancellationToken);
        }

        public async Task<IEnumerable<Contractor>> GetBy(Expression<Func<Contractor, bool>> predycate, CancellationToken cancellationToken)
        {
            var contractors = _context.Contractor.Where(x => x.IsDeleted == false);

            if (predycate != null)
            {
                contractors = contractors.Where(predycate);
            }
            return await contractors.ToListAsync(cancellationToken);
        }

        public async Task Insert(Contractor entity, CancellationToken cancellationToken)
        {
            _context.Contractor.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Contractor entity,CancellationToken cancellationToken)
        {
            _context.Contractor.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
