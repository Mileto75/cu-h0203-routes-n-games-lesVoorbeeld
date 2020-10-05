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
        //private StringBuilder _stringBuilder;

        public GamesController()
        {
            _gameRepository = new GameRepository();
           // _stringBuilder = new StringBuilder();
        }
        [Route("games")]
        [Route("games/index")]
        [Route("games/all")]
        public IActionResult Index()
        {
            //haal de games op
            var games = _gameRepository.GetGames();
            //foreach(var game in games)
            //{
            //    _stringBuilder.AppendLine("<ul>");
            //    _stringBuilder.AppendLine($"<li>Game title:{game.Title}</li>");
            //    _stringBuilder.AppendLine("</ul>");
            //}
            //format output
            var content = FormatGamesInfo(games);
            //send to browser
            return Content(content,"text/html");
        }
        
        [Route("games/showgame/{id}")]
        public IActionResult Showgame(int id)
        {
            //haal de game op uit de Db
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //format game output
            string content = FormatGameInfo(game);
            //return naar de browser
            return Content(content, "text/html");
        }



        
    }
}
