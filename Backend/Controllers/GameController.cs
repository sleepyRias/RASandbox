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

        [HttpPost("Games")]
        public IActionResult CreateGame([FromBody] Game game)
        {
            if (game == null)
            {
                return BadRequest(); // Ungültige Anforderung
            }

            _dataProvider.Games.Add(game); // Spiel der Datenquelle hinzufügen
            _dataProvider.SaveChanges(); // Speichere die Änderungen in der Datenbank

            return CreatedAtRoute("GetGameById", new { id = game.Id }, game); // Erfolgreiches Erstellen mit 201 Created-Status und dem erstellten Spiel als Antwort
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

        [HttpPut("Games/{id}")]
        public IActionResult UpdateGame(int id, [FromBody] Game updatedGame)
        {
            var game = _dataProvider.Games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound(); // Falls das Spiel mit der angegebenen ID nicht gefunden wurde
            }

            // Aktualisiere die Eigenschaften des Spiels mit den Werten aus updatedGame
            game.Name = updatedGame.Name;
            game.Genre = updatedGame.Genre;
            game.Company = updatedGame.Company;
            game.Price = updatedGame.Price;
            game.ReleaseDate = updatedGame.ReleaseDate;

            // Speichere die Änderungen in der Datenbank
            _dataProvider.SaveChanges();

            return Ok(); // Erfolgreiche Aktualisierung
        }

    }
}