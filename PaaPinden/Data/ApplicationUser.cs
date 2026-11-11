using Microsoft.AspNetCore.Identity;
using PaaPinden.Models;

namespace PaaPinden.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public byte[]? ProfilePicture { get; set; }
        public string? Bio { get; set; }

        public List<Post> Posts { get; set; } = new();
        public List<Recipe> Recipes { get; set; } = new();
        
        public List<Message> SentMessages { get; set; } = new();
        public List<Message> ReceivedMessages { get; set; } = new();

        public List<Comment> Comments { get; set; } = new();
        public List<Like> Likes { get; set; } = new();

        public List<Follow> Followers { get; set; } = new();
        public List<Follow> Following { get; set; } = new();

    }

}
