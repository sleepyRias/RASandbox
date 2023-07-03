using Microsoft.AspNetCore.Mvc;
using backend.Model;
using backend.DataProvider;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private readonly ILogger<GameController> _logger;
        private readonly SqlDataProvider _dataProvider;

        public GameController(ILogger<GameController> logger, SqlDataProvider dataProvider)
        {
            _logger = logger;
            _dataProvider = dataProvider;
        }

        // default returns entire DB
        [HttpGet(Endpoints.GameController.GetGames, Name = "GetGames")]
        public IEnumerable<Game> GetGames(int amount = 0)
        {
            if(amount > 0)
            {
                return _dataProvider.Games.Take(amount).ToList();
            }
            return _dataProvider.Games.ToList();
        }

        [HttpDelete("Games/{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = _dataProvider.Games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound(); // Falls das Spiel mit der angegebenen ID nicht gefunden wurde
            }

            _dataProvider.Games.Remove(game); // Spiel aus der Datenquelle entfernen
            _dataProvider.SaveChanges(); // Speichere die Änderungen in der Datenbank

            return NoContent(); // Erfolgreiches Löschen (kein Inhalt zurückgegeben)
        }
    }
}