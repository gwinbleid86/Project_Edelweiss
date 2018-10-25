using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Edelweiss.BLL.DTO;
using Edelweiss.DAL.Entities;
using X.PagedList;

namespace Edelweiss.BLL.Interfaces
{
    public interface IAgentService
    {
        IPagedList<AgentDTO> GetAll(int page);
        IEnumerable<AgentDTO> GetAll();
        List<User> FindAgentUsersForBlock(int id);
        AgentDTO Get(int id);
        Agent GetAgent(int id);
        AgentDTO SingleOrDefault(Func<Agent, bool> predicate);
        IQueryable<AgentDTO> Find(Expression<Func<Agent, bool>> predicate);
        void Create(AgentDTO item);
        void Update(AgentDTO item);
        void Delete(int id);
        void AgentBlock(int id);
        void AgentUnBlock(int id);
        int GetAgentByUserId(string userId);
    }
}
