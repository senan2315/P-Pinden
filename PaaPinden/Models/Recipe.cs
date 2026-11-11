using PaaPinden.Data;

namespace PaaPinden.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; } //PK

        public string ApplicationUserID { get; set; } = null!; //FK (Who made it)
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public List<Yarn> Yarns { get; set; } = new();

        public List<Comment> Comments { get; set; } = new(); //FK (Which comments are on this recipe)
        public List<Like> Likes { get; set; } = new();

        public DifficultyLevel Difficulty { get; set; }
        public enum DifficultyLevel
        { 
            Begynder,
            Øvet,
            Svært
        } 

        public DateTime CreatedAt { get; set; }     
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
