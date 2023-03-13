using Domain.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly OrderContext _context;

        public UserRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> Get(int id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default)
        {
            var users = await _context.Users.Where(x => x.IsDeleted == false).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<User>> GetBy(Expression<Func<User, bool>> predycate, CancellationToken cancellationToken = default)
        {
            var users = new List<User>();
            try
            {
                users = await _context.Users.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                ExceptionDispatchInfo.Capture(e).Throw();
            }
            if (predycate != null)
            {
                var cc = users.AsQueryable<User>();
                cc.Where(predycate);

                return await cc.ToListAsync<User>(cancellationToken);
            }
            return users;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Include(p=>p.UserRole).FirstOrDefaultAsync(x => x.Email.Contains(email));
        }

        public async Task Insert(User entity, CancellationToken cancellationToken = default)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(User entity, CancellationToken cancellationToken = default)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
