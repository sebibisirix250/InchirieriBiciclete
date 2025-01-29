using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriBiciclete.Data;
using Microsoft.EntityFrameworkCore;

namespace InchirieriBiciclete.Pages.Inchirieri
{
    public class CreateModel : PageModel
    {
        private readonly InchirieriContext _context;

        public CreateModel(InchirieriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inchiriere Inchiriere { get; set; }

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
                Console.WriteLine($"ClientId: {Inchiriere.ClientId}, BicicletaId: {Inchiriere.BicicletaId}");

                _context.Inchirieri.Add(Inchiriere);
                await _context.SaveChangesAsync();
                Console.WriteLine("Inchiriere added successfully");
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