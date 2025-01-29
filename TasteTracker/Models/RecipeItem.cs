using System.ComponentModel.DataAnnotations;

namespace TasteTracker.Models
{
    public class RecipeItem
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters are allowed.")]
        public string Name { get; set; } = "";
        [Required]
    
        public string Description { get; set; } = "";
        [Required]

        public string Ingredients { get; set; } = "";
        [Required]

        public string Instructions { get; set; } = "";

    }
}
