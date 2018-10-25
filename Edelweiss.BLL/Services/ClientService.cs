using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Infrastructure;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using X.PagedList;

namespace Edelweiss.BLL.Services
{
     public class ClientService : IClientService
    {

        IUnitOfWork Database { get; set; }
        private const int pageSize = 5;
        private int pageNumber { get; set; }

        public ClientService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IPagedList<ClientDTO> GetAll(int page)
        {

            var dbClients = Database.Clients.GetAll();
            return Mapper.Map<IEnumerable<ClientDTO>>(dbClients).ToPagedList(page, pageSize);

        }
        public IPagedList<ClientDTO> GetAllByLastName(string lastName, int page)
        {
            return Mapper.Map<IEnumerable<ClientDTO>>(Database.Clients.Contains(lastName)).ToList().ToPagedList(page, pageSize);
        }

        public ClientDTO Get(int id)
        {
            var client = Database.Clients.Get(id);
            if (client == null)
                throw new ValidationException("Клиент не найден", "");

            return Mapper.Map<ClientDTO>(client);
        }

        public ClientDTO SingleOrDefault(Func<Client, bool> predicate)
        {
            return Mapper.Map<ClientDTO>(Database.Clients.SingleOrDefault(predicate));
        }

        public IQueryable<ClientDTO> Find(Expression<Func<Client, bool>> predicate)
        {
            return Mapper.Map<IQueryable<ClientDTO>>(Database.Clients.Find(predicate));
        }

        //public IEnumerable<ClientDTO> Find(Func<Client, bool> predicate)
        //{
        //    return Mapper.Map<IEnumerable<Client>, List<ClientDTO>>(Database.Clients.Find(predicate).ToList());
        //}


        public void Create(ClientDTO client)
        {
//            var result = Database.Clients.SingleOrDefault(c =>
//                c.Name == client.Name && c.LastName == client.LastName && c.MobilePhone == client.MobilePhone);
//
//            if (result == null)
//            {
                var map = Mapper.Map<Client>(client);
                Database.Clients.Create(map);
                Database.Save();
//            }
//            else
//            {
//                var map = Mapper.Map<Client>(client);
//                Database.Clients.Update(map);
//                Database.Save();
//            }

        }

        public void Update(ClientDTO item)
        {
            var map = Mapper.Map<Client>(item);
            Database.Clients.Update(map);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Clients.Delete(id);
            Database.Save();
        }

        public ClientDTO FirstOrDefault(Func<Client, bool> predicate)
        {
            return Mapper.Map<ClientDTO>(Database.Clients.FirstOrDefault(predicate));
        }
    }
}
