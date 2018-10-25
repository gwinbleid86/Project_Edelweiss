using System.ComponentModel.DataAnnotations;

namespace Project_Edelweiss.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
