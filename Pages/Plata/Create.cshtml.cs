using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;
using Microsoft.EntityFrameworkCore;

namespace InchirieriBiciclete.Pages.Plata
{
    public class CreateModel : PageModel
    {
        private readonly InchirieriContext _context;

        public CreateModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InchirieriBiciclete.Data.Plata Plata { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Inchirieri"] = _context.Inchirieri
                .Include(i => i.Client)
                .Include(i => i.Bicicleta)
                .ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync called");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is not valid");
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            try
            {
                if (Plata == null)
                {
                    Console.WriteLine("Plata is null");
                    return Page();
                }

                Console.WriteLine($"Plata Details: InchiriereId={Plata.InchiriereId}, Suma={Plata.Suma}, DataPlata={Plata.DataPlata}");

                _context.Plati.Add(Plata);
                await _context.SaveChangesAsync();
                Console.WriteLine("Plata added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}




