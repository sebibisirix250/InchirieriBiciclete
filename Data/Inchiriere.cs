using System.ComponentModel.DataAnnotations;
using System;

namespace InchirieriBiciclete.Data
{
    public class Inchiriere
    {
        public int Id { get; set; }

        [Required]
        public int BicicletaId { get; set; }
        public Bicicleta Bicicleta { get; set; }

        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public DateTime DataInchiriere { get; set; }

        [Required]
        public DateTime DataReturnare { get; set; }
    }
}
