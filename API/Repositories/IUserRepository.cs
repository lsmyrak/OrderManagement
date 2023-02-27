using Contracts.Dtos;
using Domain.Model;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IUserRepository :IRepository<User>
    {
        public Task<User> GetUserByEmail(string email);
    }
}
