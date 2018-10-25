using System.Collections.Generic;

namespace Edelweiss.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PassportData { get; set; }
        public string MobilePhone { get; set; }
        public virtual ICollection<SysTransaction> SysTransactionsFrom { get; set; }
        public virtual ICollection<SysTransaction> SysTransactionsTo { get; set; }
    }
}
