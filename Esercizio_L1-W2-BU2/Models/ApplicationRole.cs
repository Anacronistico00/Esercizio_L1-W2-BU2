using Microsoft.AspNetCore.Identity;

namespace Esercizio_L1_W2_BU2.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

    }
}
