using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetAll()
        {
            var users = _userRepository.GetAll();

            return users.Select(user => new UserDto
            {
                
                Name = $"{user.Name}",
                Email = user.Email,
                Role = user.Role
            }).ToList();
        }
    }
}