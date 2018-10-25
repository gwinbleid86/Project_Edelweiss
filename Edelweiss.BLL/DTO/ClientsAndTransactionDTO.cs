using System;
using System.Collections.Generic;
using System.Text;

namespace Edelweiss.BLL.DTO
{
    public class ClientsAndTransactionDTO
    {
        public SysTransactionDTO SysTransactionDto { get; set; }
        public ClientDTO ClientDto { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
