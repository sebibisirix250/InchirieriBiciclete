using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;

namespace InchirieriBiciclete.Pages.Clienti
{
    public class EditModel : PageModel
    {
        private readonly InchirieriContext _context;

        public EditModel(InchirieriContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var clientToUpdate = await _context.Clienti.FindAsync(id);

            if (clientToUpdate == null)
            {
                return NotFound();
            }

            clientToUpdate.Nume = Client.Nume;
            clientToUpdate.Email = Client.Email;
            clientToUpdate.Telefon = Client.Telefon;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
