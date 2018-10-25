using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Edelweiss.BLL.Services
{
    public class TariffService : ITariffService
    {
        private IUnitOfWork Database;
        private const int pageSize = 5;
        private int pageNumber { get; set; }


        public TariffService(IUnitOfWork database)
        {
            Database = database;
        }

        public IPagedList<TariffDTO> GetAll(int page)
        {
            return Mapper.Map<IEnumerable<TariffDTO>>(Database.Tariffs.GetAll()).ToPagedList(page, pageSize);
        }

        public IEnumerable<TariffDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<TariffDTO>>(Database.Tariffs.GetAll());
        }

        public TariffDTO Get(int id)
        {
            return Mapper.Map<TariffDTO>(Database.Tariffs.Get(id));
        }

        public TariffDTO SingleOrDefault(Func<Tariff, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IQueryable<TariffDTO> Find(Expression<Func<Tariff, bool>> predicate)
        {
            return Mapper.Map<IQueryable<TariffDTO>>(Database.Tariffs.Find(predicate));
        }

        public void Create(TariffDTO item)
        {
            Database.Tariffs.Create(Mapper.Map<Tariff>(item));
            Database.Save();
        }

        public void Update(TariffDTO item)
        {
            Database.Tariffs.Update(Mapper.Map<Tariff>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Tariffs.Delete(id);
            Database.Save();
        }
    }
}
