using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using X.PagedList;

namespace Edelweiss.BLL.Services
{
    public class RangeService : IRangeService
    {
        private IUnitOfWork _database;
        private const int pageSize = 5;
        private int pageNumber { get; set; }


        public RangeService(IUnitOfWork database)
        {
            _database = database;
        }

        public IPagedList<RangeDTO> GetAll(int page)
        {
            return Mapper.Map<IEnumerable<RangeDTO>>(_database.Ranges.GetAll()).ToPagedList(page, pageSize);
        }

        public IEnumerable<RangeDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<RangeDTO>>(_database.Ranges.GetAll());
        }

        public RangeDTO Get(int id)
        {
            return Mapper.Map<RangeDTO>(_database.Ranges.Get(id));
        }

        public RangeDTO SingleOrDefault(Func<Range, bool> predicate)
        {
            return Mapper.Map<RangeDTO>(_database.Ranges.SingleOrDefault(predicate));
        }

        public IQueryable<RangeDTO> Find(Expression<Func<Range, bool>> predicate)
        {
            return Mapper.Map<IQueryable<RangeDTO>>(_database.Ranges.Find(predicate));
        }

        public void Create(RangeDTO item)
        {
            _database.Ranges.Create(Mapper.Map<Range>(item));
            _database.Save();
        }

        public void Update(RangeDTO item)
        {
            _database.Ranges.Update(Mapper.Map<Range>(item));
            _database.Save();
        }

        public void Delete(int id)
        {
            _database.Ranges.Delete(id);
            _database.Save();
        }
    }
}
