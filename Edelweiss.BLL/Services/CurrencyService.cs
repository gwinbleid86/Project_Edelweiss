using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Edelweiss.DAL.Repositories;
using X.PagedList;

namespace Edelweiss.BLL.Services
{
    public class CurrencyService : ICurrencyService
    {
        private IUnitOfWork Database { get; set; } 
        private const int pageSize = 5;
        private int pageNumber { get; set; }


        public CurrencyService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IPagedList<CurrencyDTO> GetAll(int page)
        {
            return Mapper.Map<IEnumerable<CurrencyDTO>>(Database.Currencies.GetAll()).ToPagedList(page, pageSize);
        }

        public IEnumerable<CurrencyDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<CurrencyDTO>>(Database.Currencies.GetAll());
        }

        public CurrencyDTO Get(int id)
        {
            return Mapper.Map<CurrencyDTO>(Database.Currencies.Get(id));
        }

        public CurrencyDTO SingleOrDefault(Func<Currency, bool> predicate)
        {
            return Mapper.Map<CurrencyDTO>(Database.Currencies.SingleOrDefault(predicate));
        }

        public IQueryable<CurrencyDTO> Find(Expression<Func<Currency, bool>> predicate)
        {
            return Mapper.Map<IQueryable<CurrencyDTO>>(Database.Currencies.Find(predicate));
        }

        public void Create(CurrencyDTO item)
        {
            Database.Currencies.Create(Mapper.Map<Currency>(item));
            Database.Save();
        }

        public void Update(CurrencyDTO item)
        {
            Database.Currencies.Update(Mapper.Map<Currency>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Currencies.Delete(id);
            Database.Save();
        }
    }
}
