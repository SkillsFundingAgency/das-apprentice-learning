using System;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Web.Models.GameModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DAS_Capture_The_Flag.Controllers
{
    public class GameController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GameController> _logger;

        public GameController(IMediator mediator, ILogger<GameController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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
                _logger.LogError($"{exception.Message} for GameId: {gameId}, PlayerId: {playerId}. GetGameRequestResponse = {game}");

                return RedirectToAction("Index", "Error");
            }
        }
    }
}
