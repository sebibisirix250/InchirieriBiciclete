using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;

namespace InchirieriBiciclete.Pages.Biciclete
{
    public class DeleteModel : PageModel
    {
        private readonly InchirieriContext _context;

        public DeleteModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bicicleta Bicicleta { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Bicicleta = await _context.Biciclete.FindAsync(id);

            if (Bicicleta == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var bicicletaToDelete = await _context.Biciclete.FindAsync(id);

            if (bicicletaToDelete == null)
            {
                return NotFound();
            }

            _context.Biciclete.Remove(bicicletaToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
