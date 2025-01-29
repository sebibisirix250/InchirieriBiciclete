using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;

namespace InchirieriBiciclete.Pages.Biciclete
{
    public class EditModel : PageModel
    {
        private readonly InchirieriContext _context;

        public EditModel(InchirieriContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bicicletaToUpdate = await _context.Biciclete.FindAsync(id);

            if (bicicletaToUpdate == null)
            {
                return NotFound();
            }

            bicicletaToUpdate.Nume = Bicicleta.Nume;
            bicicletaToUpdate.Model = Bicicleta.Model;
            bicicletaToUpdate.Pret = Bicicleta.Pret; 
            bicicletaToUpdate.Stare = Bicicleta.Stare; 

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
