using DragonBallAPI.Models;

namespace DragonBallAPI.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetAllAsync(string? name, string? affiliation);
        Task<Character?> GetByIdAsync(int id);
        Task<string> SyncFromExternalApiAsync();
    }
}
