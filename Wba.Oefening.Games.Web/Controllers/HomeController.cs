using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //zonder stringbuilder
            string content = "<h2>Rate-a-Game</h2>";
            content += "<a href='games/index'>Games</a> || ";
            content += "<a href='developers/index'>Developers</a>";
            return Content(content,"text/html");
        }
    }
}
