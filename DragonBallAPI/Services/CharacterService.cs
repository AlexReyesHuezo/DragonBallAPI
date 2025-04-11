using DragonBallAPI.Data;
using DragonBallAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using DragonBallAPI.DTOs;

namespace DragonBallAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpClientFactory _httpClientFactory;

        public CharacterService(ApplicationDbContext db, IHttpClientFactory httpClientFactory)
        {
            _db = db;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Character>> GetAllAsync(string? name, string? affiliation)
        {
            var query = _db.Characters.Include(c => c.Transformations).AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.Contains(name));

            if (!string.IsNullOrEmpty(affiliation))
                query = query.Where(c => c.Affiliation.Contains(affiliation));

            return await query.ToListAsync();
        }

        public async Task<Character?> GetByIdAsync(int id)
        { 
            return await _db.Characters
                .Include(c => c.Transformations)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<string> SyncFromExternalApiAsync()
        {
            if (_db.Characters.Any() || _db.Transformations.Any())
            {
                return "Database is not empty. Please clean up the data before syncing.";
            }

            var client = _httpClientFactory.CreateClient("External Dragon Ball API");
            var characterResponse = await client.GetFromJsonAsync<List<CharacterDto>>("https://dragonball-api.com/api/character");

            if (characterResponse == null) return "Failed to fetch data from external API.";

            foreach (var charDto in characterResponse.Where(c => c.Race == "Saiyan"))
            {
                var character = new Character
                {
                    Name = charDto.Name,
                    Ki = charDto.Ki,
                    Race = charDto.Race,
                    Gender = charDto.Gender,
                    Description = charDto.Description,
                    Affiliation = charDto.Affiliation,
                    Transformations = new List<Transformation>()
                };

                if (charDto.Affiliation == "Z Fighter")
                {
                    character.Transformations = charDto.Transformations.Select(t => new Transformation
                    {
                        Name = t.Name,
                        Ki = t.Ki
                    }).ToList();
                }

                _db.Characters.Add(character);
            }

            await _db.SaveChangesAsync();

            return "Data synced successfully from external API.";
        }
    }
}
