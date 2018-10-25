using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Edelweiss.BLL.Enums;
using Edelweiss.BLL.Interfaces;

namespace Edelweiss.BLL.DTO
{
    public class SysTransactionDTO
    {
        public int Id { get; set; }

        public decimal Sum { get; set; }

        public string Tcn { get; set; }

        public int TransactionStatus { get; set; }
        public DateTime CreateDateUtc { get; set; }

        public DateTime CreateDateLocal { get; set; }
        public DateTime? ConfirmDateLocal { get; set; }

        public int AgentFromId { get; set; }

        public int? AgentToId { get; set; }
        public string UserFromId { get; set; }
        public string ControllerId { get; set; }
        public string UserToId { get; set; }

        public int CountryId { get; set; }
        
        public int ClientFromId { get; set; }
        public int? ClientToId { get; set; }
        public ClientDTO ClientTo { get; set; }

        public string CurrencyName { get; set; }
        public int CurrencyId { get; set; }
        public virtual ICollection<CommissionDTO> Commissions { get; set; }
        
        public TransactionStatus Status { get; set; }
        public string ClientFromName { get; set; }
        public string ClientToName { get; set; }

        public string AgentFromName { get; set; }
        public string AgentToName { get; set; }

        public string CountryName { get; set; }
        public string AgentFromTextPromo { get; set; }

        public decimal AgentFromCommission { get; set; }
        public decimal AgentToCommission { get; set; }
        public decimal SystemCommission { get; set; }

        
        //public DateTime? ConfirmDateUtc { get; set; }
        //public DateTime? IssueDateLocal { get; set; }
        //public DateTime? IssueDateUtc { get; set; }
        //public virtual AgentDTO AgentFrom { get; set; }
        //public virtual AgentDTO AgentTo { get; set; }
        //public CountryDTO Country { get; set; }
        //public ClientDTO ClientFrom { get; set; }
    }
}
