using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;
using Microsoft.EntityFrameworkCore;

namespace InchirieriBiciclete.Pages.Biciclete
{
    public class IndexModel : PageModel
    {
        private readonly InchirieriContext _context;

        public IndexModel(InchirieriContext context)
        {
            _context = context;
        }

        public IList<Bicicleta> Biciclete { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Biciclete = await _context.Biciclete.ToListAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var bicicleta = await _context.Biciclete.FindAsync(id);
            if (bicicleta != null)
            {
                _context.Biciclete.Remove(bicicleta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
