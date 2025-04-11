using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using DragonBallAPI.Models;
using DragonBallAPI.Services;
using System.Collections.Generic;

namespace DragonBallAPI.Controllers
{
    public class CharactersController: ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        [Route("api/characters")]
        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] string? affiliation)
        {
            var characters = await _characterService.GetAllAsync(name, affiliation);
            return Ok(characters);
        }

        [HttpGet("{id}")]
        [Route("api/characters/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            return character != null ? Ok(character) : NotFound();
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncData()
        {
            var result = await _characterService.SyncFromExternalApiAsync();
            return Ok(result);
        }
    }
}
