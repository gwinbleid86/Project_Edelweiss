using System;
using System.Collections.Generic;
using System.Text;
using Edelweiss.BLL.DTO;
using Edelweiss.DAL.Entities;
using X.PagedList;

namespace Edelweiss.BLL.Interfaces
{
    public interface ICommissionsDividingService
    {
        IPagedList<CommissionsDividingDTO> GetAll(int page);
        IEnumerable<CommissionsDividingDTO> GetAll();

        CommissionsDividingDTO Get(int id);

        CommissionsDividingDTO SingleOrDefault(Func<CommissionDividing, bool> predicate);

        void Create(CommissionsDividingDTO item);

        void Update(CommissionsDividingDTO item);

        void Delete(int id);
    }
}
