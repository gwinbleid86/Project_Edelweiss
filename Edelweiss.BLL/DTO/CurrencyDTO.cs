using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Edelweiss.BLL.DTO
{
    public class CurrencyDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
