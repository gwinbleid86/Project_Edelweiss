using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Edelweiss.BLL.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Utc { get; set; }
        public int? CountQTY { get; set; }
    }
}
