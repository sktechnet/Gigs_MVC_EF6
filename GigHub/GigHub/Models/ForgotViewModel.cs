using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}