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

        public UserDto GetById(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new UserDto
            {
                Name = $"{user.Name}",
                Email = user.Email,
                Role = user.Role
            };
        }

        public void Add(UserDto userDto)
        {
            var user = new Domain.Entities.User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Role = userDto.Role
            };

            _userRepository.Add(user);
        }

        public void Update(UserDto userDto)
        {
            var user = _userRepository.GetById(userDto.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Role = userDto.Role;

            _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            _userRepository.Delete(id);
        }
    }
}