using PaaPinden.Data;
using Microsoft.EntityFrameworkCore;

namespace PaaPinden.Persistence
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetProfileByIdAsync(string userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<ApplicationUser>> GetAllProfilesAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task UpdateProfileAsync(ApplicationUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
