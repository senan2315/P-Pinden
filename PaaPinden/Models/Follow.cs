using PaaPinden.Data;

namespace PaaPinden.Models
{
    public class Follow
    {
        public int FollowID { get; set; } // PK

        public string FollowerID { get; set; } = null!; // FK (Who is following)
        public ApplicationUser Follower { get; set; } = null!;

        public string FollowingID { get; set; } = null!; // FK (Who is being followed)
        public ApplicationUser Following { get; set; } = null!; 
    }
}
