using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;
using Microsoft.EntityFrameworkCore;

namespace InchirieriBiciclete.Pages.Clienti
{
    public class IndexModel : PageModel
    {
        private readonly InchirieriContext _context;

        public IndexModel(InchirieriContext context)
        {
            _context = context;
        }

        public IList<Client> Clienti { get; set; }

        public async Task OnGetAsync()
        {
            Clienti = await _context.Clienti.ToListAsync();
        }
    }
}
