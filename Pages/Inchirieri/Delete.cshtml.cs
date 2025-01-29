using InchirieriBiciclete.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InchirieriBiciclete.Pages.Inchirieri
{
    public class DeleteModel : PageModel
    {
        private readonly InchirieriContext _context;

        public DeleteModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inchiriere Inchirieri { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Inchirieri = await _context.Inchirieri
                .Include(i => i.Client)
                .Include(i => i.Bicicleta)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Inchirieri == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (Inchirieri == null)
            {
                return NotFound();
            }

            Inchirieri = await _context.Inchirieri.FindAsync(id);

            if (Inchirieri != null)
            {
                _context.Inchirieri.Remove(Inchirieri);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
