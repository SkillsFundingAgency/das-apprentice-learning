using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DAS_Capture_The_Flag.Controllers
{
    public class GameController : Controller
    {
        public IActionResult FindGame()
        {
            return View();
        }

        public IActionResult Index(string gameId, string playerId)
        {
            return View("~/Views/Game/Index.cshtml");
        }
    }
}
