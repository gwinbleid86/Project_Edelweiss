using Edelweiss.DAL.Entities;

namespace Edelweiss.DAL.Interfaces
{
    public interface ICommissionsDividingRepository : IRepository<CommissionDividing>
    {
        CommissionDividing FirstOrDefault();
    }
}
