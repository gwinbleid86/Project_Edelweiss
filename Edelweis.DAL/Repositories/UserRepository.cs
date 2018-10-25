using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Edelweiss.DAL.EF;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;

namespace Edelweiss.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public User SingleOrDefault(Func<User, bool> predicate)
        {
            return _context.Users.SingleOrDefault(predicate);
        }

        public IQueryable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate);
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user !=  null) _context.Users.Remove(user);
        }

        public User GetByUserId(string id)
        {
            return _context.Users.Find(id);
        }

        public string GetUserRole(string id)
        {
            var result = _context.UserRoles.FirstOrDefault(u => u.UserId == id);
            var result1 = _context.Roles.FirstOrDefault(u => u.Id == result.RoleId);
            return result1.Name;
        }
    }
}
