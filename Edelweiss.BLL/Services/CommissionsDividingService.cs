using System;
using System.Collections.Generic;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using X.PagedList;

namespace Edelweiss.BLL.Services
{
    public class CommissionsDividingService : ICommissionsDividingService
    {
        private readonly IUnitOfWork _database;
        private const int pageSize = 5;
        private int pageNumber { get; set; }


        public CommissionsDividingService(IUnitOfWork database)
        {
            _database = database;
        }

        public IPagedList<CommissionsDividingDTO> GetAll(int page)
        {
            return Mapper.Map<IEnumerable<CommissionsDividingDTO>>(_database.CommissionDividing.GetAll()).ToPagedList(page, pageSize);
        }

        public IEnumerable<CommissionsDividingDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<CommissionsDividingDTO>>(_database.CommissionDividing.GetAll());
        }

        public CommissionsDividingDTO Get(int id)
        {
            return Mapper.Map<CommissionsDividingDTO>(_database.CommissionDividing.Get(id));
        }

        public CommissionsDividingDTO SingleOrDefault(Func<CommissionDividing, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(CommissionsDividingDTO item)
        {
            if (CommissionEntityChecker(item) && _database.CommissionDividing.FirstOrDefault() == null)
            {
                _database.CommissionDividing.Create(Mapper.Map<CommissionDividing>(item));
                _database.Save();
            }

            else if (CommissionEntityChecker(item) && _database.CommissionDividing.FirstOrDefault() != null)
            {
                throw new Exception("Запись в базе данных уже есть. Измените существующую запись.");
            }
            else
            {
                throw new Exception("Сумма коммиссий должна быть равна 1");
            }
        }

        public void Update(CommissionsDividingDTO item)
        {
            if (CommissionEntityChecker(item))
            {
                _database.CommissionDividing.Update(Mapper.Map<CommissionDividing>(item));
                _database.Save();
            }
            else
            {
                throw new Exception("Сумма коммиссий должна быть равна 1");
            }
        }

        public void Delete(int id)
        {
            _database.CommissionDividing.Delete(id);
        }

        private bool CommissionEntityChecker(CommissionsDividingDTO item)
        {
            decimal checker = item.AgentFromCommission + item.AgentToCommission + item.SystemCommission;

            if (checker == 1)
            {
                return true;
            }

            return false;
        }
    }
}
