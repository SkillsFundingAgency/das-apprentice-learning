using System;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using DAS_Capture_The_Flag.Web.Models.GameModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace DAS_Capture_The_Flag.Controllers
{
    public class GameController : Controller
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult FindGame()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid gameId, Guid playerId)
        {
            var game = await _mediator.Send(new GetGameRequest(gameId));

            try
            {
                var viewModel = new GameViewModel(game, playerId);

                return View(viewModel);
            }
            catch (ArgumentException exception)
            {
                // [TODO] - log the exception
                return RedirectToAction("Index", "Error");
            }
            
        }
    }
}
