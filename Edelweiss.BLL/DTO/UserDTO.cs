using System;

namespace Edelweiss.BLL.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public int AgentId { get; set; }
        public AgentDTO Agent { get; set; }
        public string UserName { get; set; }
    }
}
