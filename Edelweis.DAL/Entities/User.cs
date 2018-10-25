using System;
using Microsoft.AspNetCore.Identity;

namespace Edelweiss.DAL.Entities
{
    public class User : IdentityUser
    {
        public int AgentId { get; set; }
        public Agent Agent { get; set; }
        public string RecoveryRole { get; set; }
        //public string PassportData2 { get; set; }
        public DateTime NextPasswordChangedDate { get; set; }
        //---------------------------------
        public bool IsBlocked { get; set; }
    }
}
