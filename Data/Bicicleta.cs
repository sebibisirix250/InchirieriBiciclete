using System.ComponentModel.DataAnnotations;
namespace InchirieriBiciclete.Data
{
    public class Bicicleta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [StringLength(100, ErrorMessage = "Numele nu poate depasi 100 de caractere")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Modelul este obligatoriu")]
        [StringLength(100, ErrorMessage = "Modelul nu poate depasi 100 de caractere")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Prețul este obligatoriu")]
        [Range(1, 10000, ErrorMessage = "Pretul trebuie sa fie intre 1 și 10000")]
        public decimal Pret { get; set; }

        [Required(ErrorMessage = "Starea este obligatorie")]
        public string Stare { get; set; } 
    }
}

