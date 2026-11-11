using PaaPinden.Data;

namespace PaaPinden.Models
{
    public class Comment
    {
        public int CommentID { get; set; } //PK

        public string ApplicationUserID { get; set; } = null!; //FK (Hvem har lavet den)
        public ApplicationUser ApplicationUser { get; set; } = null!;

        //A comment NEEDS to have EITHER PostID or RecipeID, but not both.
        //This is because a comment can either be on a post or on a recipe, but not both at the same time.
        public int? PostID { get; set; } //FK (Where is it)
        public Post? Post { get; set; } 

        public int? RecipeID { get; set; } //FK (WHich recipe is it for)
        public Recipe? Recipe { get; set; }

        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }


    }

}

