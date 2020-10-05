using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DeveloperController : Controller
    {
        //declare DEveloperRepository property

        //constructor initialisation

        //action methods
        public IActionResult Index()
        {
            return View();
        }
    }
}
