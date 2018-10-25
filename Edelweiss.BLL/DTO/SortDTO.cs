using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Edelweiss.BLL.DTO
{
    public class SortDTO
    {
        public IPagedList<SysTransactionDTO> Transaction { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string AgentFrom { get; set; }
        public string AgentTo { get; set; }
        public string Fio { get; set; }
        public string Country { get; set; }
    }
}
