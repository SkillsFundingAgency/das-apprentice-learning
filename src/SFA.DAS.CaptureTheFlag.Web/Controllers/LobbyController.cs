using System;
using System.Threading;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame;
using DAS_Capture_The_Flag.Application.Handlers.UpdatePlayerReady;
using DAS_Capture_The_Flag.Web.Models.Lobby;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DAS_Capture_The_Flag.Controllers
{
    public class LobbyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LobbyController> _logger;

        public LobbyController(IMediator mediator, ILogger<LobbyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("/lobby")]
        public async Task<IActionResult> Index(Guid playerId)
        {
            var response = await _mediator.Send(new JoinOrCreateGameCommand(playerId));

            try
            {
                var viewModel = new LobbyViewModel(response.Game, playerId);

                return View(viewModel);
            }
            catch (ArgumentException exception)
            {
                _logger.LogError($"{exception.Message} for PlayerId: {playerId}. JoinOrCreateGameResponse = {response}");

                return RedirectToAction("Index", "Error");
            } 
        }

        [HttpGet("/lobby/update")]
        public async Task Ready(Guid gameId, Guid playerId) 
        { 
            await _mediator.Send(new UpdatePlayerReadyCommand(gameId, playerId), CancellationToken.None);
        }

        [HttpGet("/lobby/lobbyDetails")]
        public async Task<IActionResult> LobbyDetails(Guid gameId, Guid playerId)
        {
            var game = await _mediator.Send(new GetGameRequest(gameId), CancellationToken.None);
            
            if (game.Id == Guid.Empty)
            {
                return RedirectToAction("Index", "Error");
            }

            if (game.Players.PlayerOne.Ready && game.Players.PlayerTwo.Ready)
            {
                var redirect = new JsonResult(new { result = "RedirectToGame", url = Url.Action("Index", "Game", new { gameId, playerId }) });

                redirect.ContentType = "RedirectResult";

                return redirect;
            }

            var viewModel = new LobbyDetailsViewModel(game, playerId);

            return PartialView(viewModel);
        }

    }
}
