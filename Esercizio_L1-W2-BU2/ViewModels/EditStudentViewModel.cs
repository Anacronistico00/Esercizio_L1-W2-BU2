using System.ComponentModel.DataAnnotations;

namespace Esercizio_L1_W2_BU2.ViewModels
{
    public class EditStudentViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il Nome non può superare i 50 caratteri")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il Cognome non può superare i 50 caratteri")]
        public string? Cognome { get; set; }

        [Required(ErrorMessage = "La Data di Nascita è obbligatoria")]
        [DataType(DataType.Date)]
        public DateTime? DataDiNascita { get; set; }

        [Required(ErrorMessage = "Il campo Email è obbligatorio")]
        [EmailAddress(ErrorMessage = "Formato email non valido")]
        public string? Email { get; set; }
    }
}
