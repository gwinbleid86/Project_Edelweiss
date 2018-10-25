using System;
using System.Collections.Generic;
using System.Text;

namespace Edelweiss.BLL.DTO
{
    public class CommissionDTO
    {
        public int Id { get; set; }

        public int AgentId { get; set; }
        public AgentDTO Agent { get; set; }

        public int TransactionId { get; set; }
        public SysTransactionDTO Transaction { get; set; }

        public decimal Value { get; set; }
    }
}
