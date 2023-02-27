using Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        public Task Delete(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Role> Get(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<System.Collections.Generic.IEnumerable<Role>> GetAll(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<System.Collections.Generic.IEnumerable<Role>> GetBy(System.Linq.Expressions.Expression<System.Func<Role, bool>> predycate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Role entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Role entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
