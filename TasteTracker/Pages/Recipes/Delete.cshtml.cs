using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TasteTracker.Data;
using TasteTracker.Models;

namespace TasteTracker.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly TasteTracker.Data.TasteTrackerContext _context;

        public DeleteModel(TasteTracker.Data.TasteTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeItem RecipeItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeitem = await _context.RecipeItem.FirstOrDefaultAsync(m => m.Id == id);

            if (recipeitem == null)
            {
                return NotFound();
            }
            else
            {
                RecipeItem = recipeitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeitem = await _context.RecipeItem.FindAsync(id);
            if (recipeitem != null)
            {
                RecipeItem = recipeitem;
                _context.RecipeItem.Remove(RecipeItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
