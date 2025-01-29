using InchirieriBiciclete.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InchirieriBiciclete.Pages.Inchirieri
{
    public class EditModel : PageModel
    {
        private readonly InchirieriContext _context;

        public EditModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inchiriere Inchirieri { get; set; }
        public IList<Client> Clienti { get; set; }
        public IList<Bicicleta> Biciclete { get; set; }

        public IActionResult OnGet(int id)
        {
            Clienti = _context.Clienti.ToList();
            Biciclete = _context.Biciclete.ToList();
            Inchirieri = _context.Inchirieri.FirstOrDefault(i => i.Id == id);

            if (Inchirieri == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inchirieri).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InchirieriExists(Inchirieri.Id))
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

        private bool InchirieriExists(int id)
        {
            return _context.Inchirieri.Any(e => e.Id == id);
        }
    }
}

