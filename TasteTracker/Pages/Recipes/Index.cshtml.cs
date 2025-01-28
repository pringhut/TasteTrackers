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
    public class IndexModel : PageModel
    {
        private readonly TasteTracker.Data.TasteTrackerContext _context;

        public IndexModel(TasteTracker.Data.TasteTrackerContext context)
        {
            _context = context;
        }

        public IList<RecipeItem> RecipeItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RecipeItem = await _context.RecipeItem.ToListAsync();
        }
    }
}
