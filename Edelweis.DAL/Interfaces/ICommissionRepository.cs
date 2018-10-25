using System;
using System.Collections.Generic;
using System.Text;
using Edelweiss.DAL.Entities;

namespace Edelweiss.DAL.Interfaces
{
    public interface ICommissionRepository : IRepository<Commission>
    {
        Commission FirstOrDefault();
    }
}
