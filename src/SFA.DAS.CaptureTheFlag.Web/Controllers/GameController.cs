using System;
using System.Linq;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using DAS_Capture_The_Flag.Web.Models.Game;
using Microsoft.AspNetCore.Mvc;


namespace DAS_Capture_The_Flag.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        public IActionResult FindGame()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(Guid gameId, Guid playerId)
        {
            var game = _repository.Games.FirstOrDefault(g => g.Id == gameId);

            var viewModel = new GameViewModel(game, playerId);

            return View(viewModel);
        }

        
    }
}
