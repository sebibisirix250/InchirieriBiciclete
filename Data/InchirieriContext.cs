using Microsoft.EntityFrameworkCore;

namespace InchirieriBiciclete.Data
{
    public class InchirieriContext : DbContext
    {
        public InchirieriContext(DbContextOptions<InchirieriContext> options) 
            : base(options)
        {
        }

        public DbSet<Bicicleta> Biciclete { get; set; }
        public DbSet<Inchiriere> Inchirieri { get; set; }
        public DbSet<Client> Clienti { get; set; }
        public DbSet<Plata> Plati { get; set; }
    }
}
