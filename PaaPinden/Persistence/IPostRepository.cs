using PaaPinden.Models;

namespace PaaPinden.Persistence
{
    public interface IPostRepository
    {
        public Task<Post?> GetPostByIdAsync(int id);
        public Task<List<Post>> GetAllPostsAsync();
        public Task<List<Post>> GetPostsByUserIdAsync(string userId);
        public Task AddPostAsync(Post post);
        public Task UpdatePostAsync(Post post);
        public Task DeletePostAsync(Post post);
    }
}
