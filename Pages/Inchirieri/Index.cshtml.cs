using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InchirieriBiciclete.Data;

namespace InchirieriBiciclete.Pages.Inchirieri
{
    public class IndexModel : PageModel
    {
        private readonly InchirieriContext _context;

        public IndexModel(InchirieriContext context)
        {
            _context = context;
        }

        public IList<Inchiriere> Inchirieri { get; set; }

        public async Task OnGetAsync()
        {
            Inchirieri = await _context.Inchirieri
                .Include(i => i.Client)  
                .Include(i => i.Bicicleta) 
                .ToListAsync();

            if (Inchirieri == null)
            {
                Console.WriteLine("No Inchirieri found.");
                return;
            }

            Console.WriteLine("Inchirieri retrieved successfully");
        }
    }
}


