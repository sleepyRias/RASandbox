using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameModelController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GameModelController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET api/GameModel
        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return await _dbContext.Game.ToListAsync();
        }

        // GET api/GameModel/{email}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            return await _dbContext.Game.FindAsync(id);
        }

        // POST api/GameModel
        [Authorize]
        [HttpPost]
        public async Task Post(Game model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        //PUT api/game/{email

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Game model)
        {
            var exists = await _dbContext.Game.AnyAsync(f => f.id == id);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.Game.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}