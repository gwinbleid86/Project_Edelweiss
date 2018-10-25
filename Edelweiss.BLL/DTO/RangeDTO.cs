using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Edelweiss.BLL.DTO
{
    public class RangeDTO
    {
        public int Id { get; set; }
        [Required]
        public decimal MinValue { get; set; }
        [Required]
        public decimal MaxValue { get; set; }
    }
}
