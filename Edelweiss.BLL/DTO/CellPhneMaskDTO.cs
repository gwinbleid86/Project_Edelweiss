
using System.ComponentModel.DataAnnotations;

namespace Edelweiss.BLL.DTO
{
    public class CellPhoneMaskDTO
    {
        public int Id { get; set; }
        [Required]
        public int Mask { get; set; }
        [Required]
        public string CellPhone { get; set; }
        public string CountryName { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
