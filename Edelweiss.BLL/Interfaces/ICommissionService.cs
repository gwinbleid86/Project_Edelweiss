using System;
using System.Collections.Generic;
using System.Text;
using Edelweiss.BLL.DTO;
using Edelweiss.DAL.Entities;

namespace Edelweiss.BLL.Interfaces
{
    public interface ICommissionService
    {
        decimal GetCommissionWhenTransactionCreate(int tariffCommissionType, decimal tariffvalue, SysTransaction transaction);

        decimal GetCommissionWhenTransactionIssued(int tariffCommissionType, decimal tariffvalue,
            SysTransaction transaction);

        Tariff GetTariff(SysTransaction transaction, int agentFromId);

        void SendSmsToClientSender(int clientFromId);
    }
}
