namespace PaaPinden.Models
{
    public class Comment
    {
        public int CommentID { get; set; } //PK
        public int UserID { get; set; } //FK (Hvem har lavet den)

        //A comment NEEDS to have EITHER PostID or RecipeID, but not both. This is because a comment can either be on a post or on a recipe, but not both at the same time.
        public int PostID { get; set; } //FK (Where is it)
        public int RecipeID { get; set; } //FK (WHich recipe is it for)
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
