using System.Collections.Generic;

namespace Edelweiss.DAL.Entities
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLogo { get; set; }
        public string TextPromo { get; set; }
        public string ImagePromo { get; set; }

        public int? ParentAgentId { get; set; }
        public Agent ParentAgent { get; set; }
        //public string Address { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public bool IsBlocked { get; set; }
        public virtual ICollection<User> User { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }
        public virtual ICollection<SysTransaction> SysTransactionsFrom { get; set; }
        public virtual ICollection<SysTransaction> SysTransactionsTo { get; set; }
        
    }
}
