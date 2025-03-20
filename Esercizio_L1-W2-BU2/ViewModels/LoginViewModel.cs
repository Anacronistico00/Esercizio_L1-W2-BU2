using System.ComponentModel.DataAnnotations;

namespace Esercizio_L1_W2_BU2.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Il campo Email è obbligatorio")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Il campo Password è obbligatorio")]
        public required string Password { get; set; }
    }
}
