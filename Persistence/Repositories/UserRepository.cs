using Domain.Entities;
using Domain.Repository_interfaces;

namespace Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<User> CreateUser(User user)
        {
            return await Add(user);
        }

        public async Task<User> GetById(int id)
        {
            return await GetByCondition(x => x.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await GetAllByCondition();
        }

        public async Task<List<User>> GetAllFromCity(string city)
        {
            return await GetAllByCondition(x => x.City == city);
        }
    }
}