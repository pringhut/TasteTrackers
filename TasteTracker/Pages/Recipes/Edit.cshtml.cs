using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TasteTracker.Data;
using TasteTracker.Models;

namespace TasteTracker.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly TasteTracker.Data.TasteTrackerContext _context;

        public EditModel(TasteTracker.Data.TasteTrackerContext context)
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

            var recipeitem =  await _context.RecipeItem.FirstOrDefaultAsync(m => m.Id == id);
            if (recipeitem == null)
            {
                return NotFound();
            }
            RecipeItem = recipeitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RecipeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeItemExists(RecipeItem.Id))
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

        private bool RecipeItemExists(int id)
        {
            return _context.RecipeItem.Any(e => e.Id == id);
        }
    }
}
