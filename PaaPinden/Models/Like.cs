using PaaPinden.Data;

namespace PaaPinden.Models
{
    public class Like
    {
       
        public int LikeID { get; set; } // PK

        public string ApplicationUserID { get; set; } = null!;  // FK
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public int? PostID { get; set; } // FK
        public Post? Post { get; set; }

        public int? RecipeID { get; set; } // FK 
        public Recipe? Recipe { get; set; }
        
    }
}
