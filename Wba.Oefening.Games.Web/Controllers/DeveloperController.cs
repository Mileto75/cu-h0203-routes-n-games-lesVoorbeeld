using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Domain;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DeveloperController : Controller
    {
        //declare DeveloperRepository property
        private readonly DeveloperRepository 
            _developerRepository;
        //constructor initialisation
        public DeveloperController()
        {
            _developerRepository =
                new DeveloperRepository();
        }
        //action methods
        [Route("Developers")]
        [Route("Developers/Index")]
        [Route("Developers/All")]
        public IActionResult Index()
        {
            //haal de developers op uit repo
            var developers = _developerRepository
                .GetDevelopers();
            //format output string
            var content = FormatDevelopersInfo(developers);
            //output naar browser
            return Content(content,"text/html");
        }
        [Route("Developers/ShowDeveloper/{id}")]
        public IActionResult ShowDeveloper(int id)
        {
            //haal de developer op adhv id
            var developer = _developerRepository
                .GetDevelopers()
                .FirstOrDefault(d => d.Id == id);
            //format output
            var content = FormatDeveloperInfo(developer);
            //output naar browser
            return Content(content, "text/html");
        }

        private string FormatDeveloperInfo(Developer developer)
        {
            StringBuilder stringBuilder = 
                new StringBuilder();
            stringBuilder.AppendLine("<ul>");
            stringBuilder.AppendLine($"Id:{developer?.Id ?? 0}" +
                $", Developer:{developer?.Name ?? "NoName"}");
            stringBuilder.AppendLine("</ul>");
            return stringBuilder.ToString();
        }

        private string FormatDevelopersInfo
            (IEnumerable<Developer> developers)
        {
            StringBuilder stringBuilder 
                = new StringBuilder();
            //lus door de developers en 
            //roep FormatdeveloperInfo aan
            foreach(var developer in developers)
            {
                stringBuilder.AppendLine
                    (FormatDeveloperInfo(developer));
            }
            //return
            return stringBuilder.ToString();
        }
    }
}
