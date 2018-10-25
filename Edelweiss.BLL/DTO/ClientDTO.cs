using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Edelweiss.BLL.DTO
{
    public class ClientDTO
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        //[Required]
        public string PassportData { get; set; }

        [Required]
        [MaxLength(15)]
        public string MobilePhone { get; set; }
    }
}
