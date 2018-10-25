using System;
using System.Collections.Generic;

namespace Edelweiss.DAL.Entities
{
    public class SysTransaction
    {
        public int Id { get; set; }
        
        public decimal Sum { get; set; }

        public string Tcn { get; set; }

        public int TransactionStatus { get; set; }

        public DateTime CreateDateUtc { get; set; }
        public DateTime? ConfirmDateUtc { get; set; }

        public DateTime CreateDateLocal { get; set; }
        public DateTime? ConfirmDateLocal { get; set; }

        public DateTime? IssueDateLocal { get; set; }
        public DateTime? IssueDateUtc { get; set; }
            
        public int AgentFromId { get; set; }
        public virtual Agent AgentFrom { get; set; }

        public int? AgentToId { get; set; }
        public virtual Agent AgentTo { get; set; }

        public string UserFromId { get; set; }
        public string ControllerId { get; set; }
        public string UserToId { get; set; }

        public int ClientFromId { get; set; }
        public Client ClientFrom { get; set; }
        public int? ClientToId { get; set; }
        public Client ClientTo { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public virtual ICollection<Commission> Commissions { get; set; }
    }
}
