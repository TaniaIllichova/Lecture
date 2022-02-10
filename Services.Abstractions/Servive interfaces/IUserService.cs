using WebApplication2.Models.DTOs;

namespace Services.Abstractions.Servive_interfaces
{
    public interface IUserService
    {
        [Obsolete("Obsolete, use GetUserDetailsAsync(int id)")]
        Task<UserDetailsDto> GetUser();

        Task AddUserAsync(CreateUserDto user);
        Task<UserDetailsDto> GetUserDetailsAsync(int id);
        Task<List<UserDto>> GetAllUsersAsync();
    }
}