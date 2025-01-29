using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InchirieriBiciclete.Data; 

namespace InchirieriBiciclete.Pages.Plati
{
    public class IndexModel : PageModel
    {
        private readonly InchirieriContext _context;

        public IndexModel(InchirieriContext context)
        {
            _context = context;
        }

        public IList<InchirieriBiciclete.Data.Plata> Plati { get; set; }  // Fully qualified name

        public async Task OnGetAsync()
        {
            Plati = await _context.Plati
                .Include(p => p.Inchiriere)
                .ThenInclude(i => i.Client)
                .ToListAsync();
        }
    }
}

