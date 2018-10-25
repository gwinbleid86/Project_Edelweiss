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
    public interface ICurrencyService
    {
        IPagedList<CurrencyDTO> GetAll(int page);
        IEnumerable<CurrencyDTO> GetAll();
        CurrencyDTO Get(int id);
        CurrencyDTO SingleOrDefault(Func<Currency, bool> predicate);
        IQueryable<CurrencyDTO> Find(Expression<Func<Currency, bool>> predicate);
        void Create(CurrencyDTO item);
        void Update(CurrencyDTO item);
        void Delete(int id);
    }
}
