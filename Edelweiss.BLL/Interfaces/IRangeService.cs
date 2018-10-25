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
    public interface IRangeService 
    {
        IPagedList<RangeDTO> GetAll(int page);
        IEnumerable<RangeDTO> GetAll();
        RangeDTO Get(int id);
        RangeDTO SingleOrDefault(Func<Range, bool> predicate);
        IQueryable<RangeDTO> Find(Expression<Func<Range, bool>> predicate);
        void Create(RangeDTO item);
        void Update(RangeDTO item);
        void Delete(int id);
    }
}
