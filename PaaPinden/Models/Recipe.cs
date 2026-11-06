namespace PaaPinden.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; } //PK
        public int UserID { get; set; } //FK (Who made it)
        public List<Yarn> Yarns { get; set; } //FK (Which yarns are used)
        public List<Comment> Comments { get; set; } //FK (Which comments are on this recipe)
        public string Title { get; set; }
        public Enum Difficulty { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Like { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
