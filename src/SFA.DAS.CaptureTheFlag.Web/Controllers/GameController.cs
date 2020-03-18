using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.ViewModels;
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
            //var map = new Map();

            //game.GameBoard = new string[5, 5]
            //  {
            //    { "grass", "wall", "wall", "wall", "wall"},
            //    { "wall", "wall", "grass", "grass", "grass"},
            //    { "grass", "grass", "grass", "grass", "grass"},
            //    { "grass", "grass", "grass", "grass", "grass"},
            //    { "grass", "grass", "grass", "grass", "grass"}
            //  };
            //game.PlayerSoldiers = new List<Soldier>();
            //game.PlayerSoldiers.Add(new Soldier("Ben", 100, 1, 1));

            //return View(game);

            return View("~/Views/Game/Index.cshtml");
        }

        
    }
}