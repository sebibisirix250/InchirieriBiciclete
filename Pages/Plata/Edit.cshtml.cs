using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;
using Microsoft.EntityFrameworkCore;

namespace InchirieriBiciclete.Pages.Plata
{
    public class EditModel : PageModel
    {
        private readonly InchirieriContext _context;

        public EditModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InchirieriBiciclete.Data.Plata Plata { get; set; }  // Fully qualified name

        public IList<Inchiriere> Inchirieri { get; set; }  // Corrected name

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plata = await _context.Plati
                .Include(p => p.Inchiriere)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Plata == null)
            {
                return NotFound();
            }

            Inchirieri = await _context.Inchirieri.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Plata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlataExists(Plata.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlataExists(int id)
        {
            return _context.Plati.Any(e => e.Id == id);
        }
    }
}
