using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Domain;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;
        private readonly StringBuilder _stringBuilder;

        public GamesController()
        {
            _gameRepository = new GameRepository();
            _stringBuilder = new StringBuilder();
        }
        [Route("games/index")]
        public IActionResult Index()
        {
            var games = _gameRepository.GetGames();
            foreach(var game in games)
            {
                _stringBuilder.AppendLine("<ul>");
                _stringBuilder.AppendLine($"<li>Game title:{game.Title}</li>");
                _stringBuilder.AppendLine("</ul>");
            }
            return Content(_stringBuilder.ToString(),"text/html");
        }
        
        [Route("games/showgame/{id}")]
        public IActionResult Showgame(int id)
        {
            //haal de game op uit de Db
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //input string opbouwen
            _stringBuilder.AppendLine("<ul>");
            _stringBuilder.AppendLine
                ($"<li>Title:{game?.Title ?? "NoTitle"}" +
                $":Developer{game?.Developer?.Name ?? "NoName"}</li>");
            _stringBuilder.AppendLine("</ul>");
            //return naar de browser
            return Content(_stringBuilder.ToString(), "text/html");
        }
    }
}
