using System.ComponentModel.DataAnnotations;

namespace TasteTracker.Models
{
    public class RecipeItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]

        public string Description { get; set; } = "";
        [Required]

        public string Ingredients { get; set; } = "";
        [Required]

        public string Instructions { get; set; } = "";

    }
}
