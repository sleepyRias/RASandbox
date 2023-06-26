namespace backend.Controllers
{
    public class Endpoints
        {
        private const string Base = "/api";

        public static class GameController
        {
            private const string ControllerBase = Base + "/GameController";

            public const string GetWeatherForecast = ControllerBase;
            public const string GetGames = ControllerBase + "/Games";
        }
    }
}
