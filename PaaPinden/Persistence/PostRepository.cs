using PaaPinden.Models;
using PaaPinden.Data;
using Microsoft.EntityFrameworkCore;

namespace PaaPinden.Persistence
{
    public class PostRepository : IPostRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public PostRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddPostAsync(Post post)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.Add(post);
            await context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(Post post)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var recipe = await context._posts
                .FirstOrDefaultAsync(p => p.PostID == post.PostID);
            if (recipe == null)
            {
                return;
            }
            if (recipe != null)
            {
                context._posts.Remove(recipe);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context._posts.ToListAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context._posts.FindAsync(id);
        }

        public async Task<List<Post>> GetPostsByUserIdAsync(string userId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context._posts.Where(p => p.ApplicationUserID == userId).ToListAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context._posts.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
