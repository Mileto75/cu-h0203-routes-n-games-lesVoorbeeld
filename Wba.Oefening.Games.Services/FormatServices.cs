using System;
using System.Collections.Generic;
using System.Text;
using Wba.Oefening.Games.Domain;

namespace Wba.Oefening.Games.Services
{
    //zou in principe ook static kunnen en mogen
    public class FormatServices
    {
        //format methods games
        public string FormatGameInfo(Game game)
        {
            StringBuilder _stringBuilder = new StringBuilder();
            //input string opbouwen
            _stringBuilder.AppendLine("<ul>");
            _stringBuilder.AppendLine
                ($"<li><a href='https://localhost:5001/games/Showgame/{game.Id}'>Title:{game?.Title ?? "NoTitle"}" +
                $":Developer{game?.Developer?.Name ?? "NoName"}</a></li>");
            _stringBuilder.AppendLine("</ul>");
            return _stringBuilder.ToString();
        }

        public string FormatGamesInfo(IEnumerable<Game> games)
        {
            StringBuilder _stringBuilder = new StringBuilder();
            foreach (var game in games)
            {
                _stringBuilder
                    .AppendLine(FormatGameInfo(game));
            }
            return _stringBuilder.ToString();

        }
        //format methods Developer
        public string FormatDeveloperInfo(Developer developer)
        {
            StringBuilder stringBuilder =
                new StringBuilder();
            stringBuilder.AppendLine("<ul>");
            stringBuilder.AppendLine($"<li>" +
                $"<a href='https://localhost:5001/developers/ShowDeveloper/{developer.Id}'>Id:{developer?.Id ?? 0}" +
                $", Developer:{developer?.Name ?? "NoName"}</a></li>");
            stringBuilder.AppendLine("</ul>");
            return stringBuilder.ToString();
        }

        public string FormatDevelopersInfo
            (IEnumerable<Developer> developers)
        {
            StringBuilder stringBuilder
                = new StringBuilder();
            //lus door de developers en 
            //roep FormatdeveloperInfo aan
            foreach (var developer in developers)
            {
                stringBuilder.AppendLine
                    (FormatDeveloperInfo(developer));
            }
            //return
            return stringBuilder.ToString();
        }
    }
}
