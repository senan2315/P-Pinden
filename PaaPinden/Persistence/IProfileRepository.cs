using PaaPinden.Data;


namespace PaaPinden.Persistence
{
    public interface IProfileRepository
    {
        Task<ApplicationUser?> GetProfileByIdAsync(string userId);
        Task<List<ApplicationUser>> GetAllProfilesAsync();
        Task UpdateProfileAsync(ApplicationUser user);
    }
}
