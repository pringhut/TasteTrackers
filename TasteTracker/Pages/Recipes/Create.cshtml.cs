using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TasteTracker.Data;
using TasteTracker.Models;

namespace TasteTracker.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly TasteTracker.Data.TasteTrackerContext _context;

        public CreateModel(TasteTracker.Data.TasteTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecipeItem RecipeItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecipeItem.Add(RecipeItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
