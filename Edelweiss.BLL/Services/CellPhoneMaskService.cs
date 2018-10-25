using System;
using System.Collections.Generic;
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
    public class CellPhoneMaskService : ICellPhoneMaskService
    {
        IUnitOfWork Database { get; set; }
        private const int pageSize = 5;
        private int pageNumber { get; set; }


        public CellPhoneMaskService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IPagedList<CellPhoneMaskDTO> GetAll(int page)
        {
            var cell = Database.CellPhoneMasks.GetAll();
            return Mapper.Map<IEnumerable<CellPhoneMask>, List<CellPhoneMaskDTO>>(cell).ToPagedList(page, pageSize);
        }
        public IEnumerable<CellPhoneMaskDTO> GetAll()
        {
            var cell = Database.CellPhoneMasks.GetAll();
            return Mapper.Map<IEnumerable<CellPhoneMask>, List<CellPhoneMaskDTO>>(cell);
        }

        public CellPhoneMaskDTO Get(int id)
        {
            var cell = Database.CellPhoneMasks.Get(id);
            if (cell == null)
                throw new ValidationException("Агент не найден", "");

            return Mapper.Map<CellPhoneMaskDTO>(cell);
        }

        public CellPhoneMaskDTO SingleOrDefault(Func<CellPhoneMask, bool> predicate)
        {
            return Mapper.Map<CellPhoneMaskDTO>(Database.CellPhoneMasks.SingleOrDefault(predicate));
        }

        public IEnumerable<CellPhoneMaskDTO> Find(Expression<Func<CellPhoneMask, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<CellPhoneMaskDTO>>(Database.CellPhoneMasks.Find(predicate));
        }

        public void Create(CellPhoneMaskDTO item)
        {
            var map = Mapper.Map<CellPhoneMask>(item);
            Database.CellPhoneMasks.Create(map);
            Database.Save();
        }

        public void Update(CellPhoneMaskDTO item)
        {
            var map = Mapper.Map<CellPhoneMask>(item);
            Database.CellPhoneMasks.Update(map);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.CellPhoneMasks.Delete(id);
            Database.Save();
        }
    }
}
