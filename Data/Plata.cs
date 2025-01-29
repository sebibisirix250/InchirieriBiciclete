using System.ComponentModel.DataAnnotations;

namespace InchirieriBiciclete.Data
{
    public class Plata
    {
        public int Id { get; set; }

        [Required]
        public int InchiriereId { get; set; }
        public Inchiriere Inchiriere { get; set; }

        [Required]
        public decimal Suma { get; set; }

        [Required]
        public DateTime DataPlata { get; set; }
    }
}

