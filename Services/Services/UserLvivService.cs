using AutoMapper;
using Domain.Entities;
using Domain.Repository_interfaces;
using Services.Abstractions.Servive_interfaces;
using WebApplication2.Models.DTOs;

namespace Services.Services
{
    public class UserLvivService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserLvivService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailsDto> GetUser()
        {
            return new UserDetailsDto()
            {
                FullName = "John Smith",
                Age = 22,
                City = "Lviv",
                Country = "Ukraine",
                Email = "email@gmail.com"
            };
        }

        public async Task AddUserAsync(CreateUserDto user)
        {
            await _userRepository.CreateUser(_mapper.Map<User>(user));
        }

        public async Task<UserDetailsDto> GetUserDetailsAsync(int id)
        {
            var user = await _userRepository.GetById(id);

            return _mapper.Map<UserDetailsDto>(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllFromCity("Lviv");
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}