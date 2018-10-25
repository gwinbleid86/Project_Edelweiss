using System.ComponentModel.DataAnnotations;

namespace Project_Edelweiss.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
