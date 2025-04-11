using DragonBallAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DragonBallAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransformationsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TransformationsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transformations = await _db.Transformations
                .Include(t => t.Character)
                .ToListAsync();
            return Ok(transformations);
        }
    }
}
