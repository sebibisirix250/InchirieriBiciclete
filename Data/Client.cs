using System.ComponentModel.DataAnnotations;

namespace InchirieriBiciclete.Data
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [StringLength(100, ErrorMessage = "Numele nu poate depasi 100 de caractere")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Email-ul este obligatoriu")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefonul este obligatoriu")]
        [StringLength(15, ErrorMessage = "Telefonul nu poate depasi 15 caractere")]
        public string Telefon { get; set; }
    }
}
