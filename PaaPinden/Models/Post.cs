namespace PaaPinden.Models
{
    public class Post
    {
        public int PostID { get; set; } //PK
        public int UserID { get; set; } //FK (Who made the post)
        public List<Comment> Comments { get; set; } //FK (Which comments are on this post)
        public Byte[] Image { get; set; } //Image data
        public Byte[] Video { get; set; } //Video data
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public string Author { get; set; }

    }
}
