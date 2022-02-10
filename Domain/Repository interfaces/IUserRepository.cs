using Domain.Entities;

namespace Domain.Repository_interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        Task<List<User>> GetAllFromCity(string city);
    }
}