
using DAS_Capture_The_Flag.Models.Game;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DAS_Capture_The_Flag.Controllers
{
    public class GameController : Controller
    {
        private IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }
        public IActionResult FindGame()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(string gameId, string playerId)
        {
            var game = _repository.Games.FirstOrDefault(g => g.Id == gameId);

            var viewModel = new GameViewModel(game, playerId);

            return View("~/Views/Game/Index.cshtml", viewModel);
        }

        
    }
}