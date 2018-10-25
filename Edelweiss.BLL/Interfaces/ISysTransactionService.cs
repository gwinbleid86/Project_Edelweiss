using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Enums;
using Edelweiss.DAL.Entities;
using X.PagedList;

namespace Edelweiss.BLL.Interfaces
{
    public interface ISysTransactionService
    {
        IPagedList<SysTransactionDTO> GetAll(int page);
        IPagedList<SysTransactionDTO> GetAllByUserId(string userId, int page);
        SysTransactionDTO Get(int id);
        ClientsAndTransactionDTO GetClientsAndTransactionDTO(int id);
        SysTransactionDTO SingleOrDefault(Func<SysTransaction, bool> predicate);
        SysTransactionDTO SingleIncludeAgents(int id);

        IEnumerable<SysTransactionDTO> Find(Expression<Func<SysTransaction, bool>> predicate);
        //---------------------------------   Controller Views   -----------------------------------
        IPagedList<SysTransactionDTO> AllForControllerAsSubAgent(string userId, int page);
        IPagedList<SysTransactionDTO> AllForControllerAsAgent(string userId, int page);
        IPagedList<SysTransactionDTO> AllTransactionsToPayOff(string userId, int page);
        IPagedList<SysTransactionDTO> AllTransactionsCanceled(string userId, int page);
        IPagedList<SysTransactionDTO> AllByStatusAndUserId(string userId, string value, int page);
        IPagedList<SysTransactionDTO> AllTransactionsCantCanceled(string userId, string value, int page);

        void Create(ClientsAndTransactionDTO item, string userId);
        bool StatusToPayAndApproved(int id, string value);
        bool StatusConfirmed(int id, string userId);
        bool StatusToPayOff(int id, string userId);
        bool StatusToIssued(int id);
        bool StatusToCanceled(int id);

        void Update(SysTransactionDTO item);
        ClientsAndTransactionDTO Copy(int id, string userId, int clientToId, int clientFromId);
        void Delete(int id);
        SortDTO Sort(
            string tcn,
            string country,
            string agentTo, 
            string agentFrom,
            DateTime timeFrom,
            DateTime timeTo,
            string fio,
            int page,
            string userId,
            SortState sortOrder);

        bool Checker(int transactionId, string userId);
    }
}
