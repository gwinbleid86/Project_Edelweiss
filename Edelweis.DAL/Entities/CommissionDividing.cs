using System;
using System.Collections.Generic;
using System.Text;

namespace Edelweiss.DAL.Entities
{
    public class CommissionDividing
    {
        public int Id { get; set; }
        public decimal AgentFromCommission { get; set; }
        public decimal AgentToCommission { get; set; }
        public decimal SystemCommission { get; set; }
    }
}
