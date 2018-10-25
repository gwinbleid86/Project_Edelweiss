using System;
using System.Collections.Generic;
using System.Text;

namespace Edelweiss.BLL.DTO
{
    public class CommissionsDividingDTO
    {
        public int Id { get; set; }
        public decimal AgentFromCommission { get; set; }
        public decimal AgentToCommission { get; set; }
        public decimal SystemCommission { get; set; }
    }
}
