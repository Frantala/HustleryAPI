using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? Authenticate(string username, string password)
        {
            User? userToAuthenticate = _context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

            // ya retorna nulo 
            return userToAuthenticate;

        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            var users =  _context.Users.FirstOrDefault(u => u.Id == id);

            if(users == null)
            {
                throw new Exception("User not found");
            }

            return users;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var users = _context.Users.ToList();

            if (users.Any())
            {
                _context.Users.RemoveRange(users);
                _context.SaveChanges();
            }

            _context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name = 'Users'");
        }
    }
}
