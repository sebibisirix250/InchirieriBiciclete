using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;

namespace InchirieriBiciclete.Pages.Biciclete
{
    public class CreateModel : PageModel
    {
        private readonly InchirieriContext _context;

        public CreateModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bicicleta Bicicleta { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Biciclete.Add(Bicicleta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}





