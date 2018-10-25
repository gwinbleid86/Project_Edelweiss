using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Edelweiss.BLL.DTO;
using Edelweiss.DAL.Entities;
using X.PagedList;

namespace Edelweiss.BLL.Interfaces
{
    public interface IClientService
    {
        IPagedList<ClientDTO> GetAll(int page);
        ClientDTO Get(int id);
        ClientDTO SingleOrDefault(Func<Client, bool> predicate);
        ClientDTO FirstOrDefault(Func<Client, bool> predicate);
        IQueryable<ClientDTO> Find(Expression<Func<Client, bool>> predicate);
        IPagedList<ClientDTO> GetAllByLastName(string lastName, int page);
        void Create(ClientDTO item);
        void Update(ClientDTO item);
        void Delete(int id);
    }
}
