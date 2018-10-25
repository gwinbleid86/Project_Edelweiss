using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Edelweiss.BLL.DTO
{
    public class AgentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageLogo { get; set; }
        public string TextPromo { get; set; }
        public IFormFile ImagePromo { get; set; }
        public int? ParentAgentId { get; set; }
        public string ParentAgentName { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }


        public bool IsBlocked { get; set; }
    }
}
