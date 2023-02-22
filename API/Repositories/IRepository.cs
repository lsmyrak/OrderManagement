using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Get(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> predycate, CancellationToken cancellationToken = default);
        Task Update(T entity, CancellationToken cancellationToken = default);
        Task Delete(int id, CancellationToken cancellationToken = default);
        Task Insert(T entity, CancellationToken cancellationToken = default);
    }
}
