using PaaPinden.Data;

namespace PaaPinden.Models
{
    public class Post
    {
        public int PostID { get; set; } //PK

        public string ApplicationUserID { get; set; } = null!; //FK (Who made the post)
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public List<Comment> Comments { get; set; } = new(); //FK (Which comments are on this post)
        public List<Like> Likes { get; set; } = new();

        public Byte[] Image { get; set; } //Image data
        public Byte[] Video { get; set; } //Video data

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }      
        public string Author { get; set; } = null!; 


    }
}
