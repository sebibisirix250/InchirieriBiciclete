using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;

namespace InchirieriBiciclete.Pages.Clienti
{
    public class DeleteModel : PageModel
    {
        private readonly InchirieriContext _context;

        public DeleteModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Client = await _context.Clienti.FindAsync(id);

            if (Client == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Client = await _context.Clienti.FindAsync(id);

            if (Client != null)
            {
                _context.Clienti.Remove(Client);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
