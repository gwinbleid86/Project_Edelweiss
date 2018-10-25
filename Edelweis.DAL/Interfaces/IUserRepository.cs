using Edelweiss.DAL.Entities;

namespace Edelweiss.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserId(string id);
        string GetUserRole(string id);
    }
}
