using PaaPinden.Models;
using PaaPinden.Data;
using Microsoft.EntityFrameworkCore;


namespace PaaPinden.Persistence
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddRecipeAsync(Recipe recipe)
        {
            _context.Recipe.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipe.Remove(recipe);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipe.ToListAsync();
        }

        // dette skal vi lige snakke om.

        public Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetRecipesByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
        // --------------------------------------^^
        public async Task<List<Recipe>> SearchRecipesAsync(string searchTerm)
        {
            return await _context.Recipe
                .Where(r => r.Title.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            _context.Recipe.Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
