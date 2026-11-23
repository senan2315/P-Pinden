using PaaPinden.Models;

namespace PaaPinden.Persistence
{
    public interface IRecipeRepository
    {
        public Task<Recipe?> GetRecipeByIdAsync(int id);
        public Task<List<Recipe>> GetAllRecipesAsync();
        public Task<List<Recipe>> GetRecipesByUserIdAsync(string userId);
        public Task AddRecipeAsync(Recipe recipe);
        public Task UpdateRecipeAsync(Recipe recipe);
        public Task DeleteRecipeAsync(int id);
        public Task<List<Recipe>> SearchRecipesAsync(string searchTerm);
    }
}
