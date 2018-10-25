using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Edelweiss.BLL.DTO;
using Edelweiss.DAL.Entities;
using X.PagedList;

namespace Edelweiss.BLL.Interfaces
{
    public interface ITariffService
    {
        IPagedList<TariffDTO> GetAll(int page);
        IEnumerable<TariffDTO> GetAll();
        TariffDTO Get(int id);
        TariffDTO SingleOrDefault(Func<Tariff, bool> predicate);
        IQueryable<TariffDTO> Find(Expression<Func<Tariff, bool>> predicate);
        void Create(TariffDTO item);
        void Update(TariffDTO item);
        void Delete(int id);
    }
}
