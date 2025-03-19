using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Esercizio_L1_W2_BU2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required DateOnly BirthDate { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

    }
}
