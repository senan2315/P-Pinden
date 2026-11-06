namespace PaaPinden.Models
{
    public class User
    {
        public int UserId { get; set; } //PK
        public List<Recipe> Recipes { get; set; } //FK (Which recipes are made by this user)
        public List<Post> Posts { get; set; } //FK (Which posts are made by this user)
        public List<Message> Messages { get; set; } //FK (Which messages are sent by this user)
        public string Username { get; set; }
        public Byte[] ProfilePicture { get; set; } //Image data
        public string Bio { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
    }
}
