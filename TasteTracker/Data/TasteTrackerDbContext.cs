using Microsoft.EntityFrameworkCore;
using TasteTracker.Models;

namespace TasteTracker.Data
{
    public class TasteTrackerContext(DbContextOptions<TasteTrackerContext> options) : DbContext(options)
    {
        public DbSet<RecipeItem> RecipeItem { get; set; }
    }
}