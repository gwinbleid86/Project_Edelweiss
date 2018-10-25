using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Edelweiss.BLL.DTO;
using Edelweiss.DAL.Entities;
using X.PagedList;

namespace Edelweiss.BLL.Interfaces
{
    public interface ICellPhoneMaskService
    {
        IPagedList<CellPhoneMaskDTO> GetAll(int page);
        IEnumerable<CellPhoneMaskDTO> GetAll();
        CellPhoneMaskDTO Get(int id);
        CellPhoneMaskDTO SingleOrDefault(Func<CellPhoneMask, bool> predicate);
        IEnumerable<CellPhoneMaskDTO> Find(Expression<Func<CellPhoneMask, bool>> predicate);
        void Create(CellPhoneMaskDTO item);
        void Update(CellPhoneMaskDTO item);
        void Delete(int id);
    }
}
