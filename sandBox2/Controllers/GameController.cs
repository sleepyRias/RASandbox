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


        [HttpGet(Endpoints.GameController.GetGames, Name = "GetGames")]
        public IEnumerable<Game> GetGames()
        {
            var games = _dataProvider.Games.ToList();
            return games;
        }
    }
}