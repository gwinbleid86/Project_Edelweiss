using System;
using Edelweiss.BLL.Enums;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Interfaces;
using Edelweiss.DAL.Entities;

namespace Edelweiss.BLL.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly IUnitOfWork _database;
        private CommissionDividing CommissionDividing { get; set; }
        private decimal Divide { get; set; }

        public CommissionService(IUnitOfWork database)
        {
            _database = database;
            CommissionDividing = _database.CommissionDividing.FirstOrDefault();
        }

        public decimal GetCommissionWhenTransactionCreate(int tariffCommissionType, decimal tariffvalue, SysTransaction transaction)
        {
            if (tariffCommissionType == (int)CommissionType.Fixed)
            {
                Divide = CommissionDividing.AgentFromCommission * tariffvalue;
                _database.Commissions.Create(new Commission()
                {
                    AgentId = transaction.AgentFromId,
                    Transaction = transaction,
                    Value = CommissionDividing.AgentFromCommission * tariffvalue
                });
                _database.Save();
                return transaction.Sum - Divide;
            }
            else
            {
                Divide = CommissionDividing.AgentFromCommission * (transaction.Sum * tariffvalue / 100);
                _database.Commissions.Create(new Commission()
                {
                    AgentId = transaction.AgentFromId,
                    Transaction = transaction,
                    Value = CommissionDividing.AgentFromCommission * (transaction.Sum * tariffvalue / 100)
                });
                _database.Save();
            }
            return transaction.Sum - Divide;
        }

        public decimal GetCommissionWhenTransactionIssued(int tariffCommissionType, decimal tariffvalue, SysTransaction transaction)
        {
            Agent system = _database.Agents.SingleOrDefault(a => a.Name == "System");
            if (transaction.TransactionStatus <= (int)TransactionStatus.Confirmed)
            {
                return transaction.Sum;
            }
            else
            {
                if (tariffCommissionType == (int)CommissionType.Fixed)
                {
                    Divide = CommissionDividing.AgentToCommission * tariffvalue +
                             CommissionDividing.SystemCommission * tariffvalue;
                    _database.Commissions.Create(new Commission()
                    {
                        AgentId = transaction.AgentToId.GetValueOrDefault(),
                        Transaction = transaction,
                        Value = CommissionDividing.AgentToCommission * tariffvalue
                    });
                    _database.Commissions.Create(new Commission()
                    {
                        AgentId = system.Id,
                        Transaction = transaction,
                        Value = CommissionDividing.SystemCommission * tariffvalue
                    });
                    _database.Save();
                    return transaction.Sum - Divide;
                }
                else
                {
                    Divide = CommissionDividing.AgentToCommission * (transaction.Sum * tariffvalue / 100) +
                             CommissionDividing.SystemCommission * (transaction.Sum * tariffvalue / 100);
                    _database.Commissions.Create(new Commission()
                    {
                        AgentId = transaction.AgentToId.GetValueOrDefault(),
                        Transaction = transaction,
                        Value = CommissionDividing.AgentToCommission * (transaction.Sum * tariffvalue / 100)
                    });
                    _database.Commissions.Create(new Commission()
                    {
                        AgentId = system.Id,
                        Transaction = transaction,
                        Value = CommissionDividing.SystemCommission * (transaction.Sum * tariffvalue / 100)
                    });
                    _database.Save();
                    return transaction.Sum - Divide;
                }
            }
            
        }

        public Tariff GetTariff(SysTransaction transaction, int agentFromId)
        {
            Agent agent = _database.Agents.Get(agentFromId);
            Range range = _database.Ranges.SingleOrDefault(r => r.MinValue <= transaction.Sum
                    && r.MaxValue >= transaction.Sum);
            Currency currency = _database.Currencies.SingleOrDefault(c => c.Id == Convert.ToInt32(transaction.CurrencyId));
            if (agent.ParentAgentId != null)
            {
                agentFromId = (int) agent.ParentAgentId;
            }
            Tariff tariff = _database.Tariffs.SingleOrDefault
                            (
                                t => t.CountryId == transaction.CountryId
                                     && t.RangeId == range.Id
                                     && t.CurrencyId == currency.Id
                                     && t.AgentId == agentFromId            
                            ) ?? _database.Tariffs.SingleOrDefault
                            (
                                t => t.CountryId == transaction.CountryId
                                     && t.RangeId == range.Id
                                     && t.CurrencyId == currency.Id
                                     && t.AgentId == null
                            );

            return tariff;
        }

        public void SendSmsToClientSender(int clientFromId)
        {
            Client client = _database.Clients.Get(clientFromId);
            //SendSms(client.MobilePhone);
        }
    }
}
