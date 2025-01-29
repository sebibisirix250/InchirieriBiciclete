using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;

namespace InchirieriBiciclete.Pages.Plata
{
    public class DeleteModel : PageModel
    {
        private readonly InchirieriContext _context;

        public DeleteModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InchirieriBiciclete.Data.Plata Plata { get; set; }  // Fully qualified name

        public IActionResult OnGet(int id)
        {
            Plata = _context.Plati
                .FirstOrDefault(m => m.Id == id);

            if (Plata == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Plata == null)
            {
                return NotFound();
            }

            _context.Plati.Remove(Plata);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}

