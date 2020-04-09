using System;
using System.Threading;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame;
using DAS_Capture_The_Flag.Application.Handlers.UpdatePlayerReady;
using DAS_Capture_The_Flag.Web.Models.Lobby;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DAS_Capture_The_Flag.Controllers
{
    public class LobbyController : Controller
    {
        private readonly IMediator _mediator;

        public LobbyController(IMediator mediator)
        {
            _mediator = mediator;
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
                return RedirectToAction("Index", "Error");
            } 
        }

        [HttpGet("/lobby/refresh")]
        public async Task<string> Refresh(Guid gameId)
        {
            var game = await _mediator.Send(new GetGameRequest(gameId), CancellationToken.None);

            return JsonConvert.SerializeObject(game);
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

            if 
            var viewModel = new LobbyDetailsViewModel(game, playerId);

            return PartialView(viewModel);
        }

        //[HttpPost("/lobby/LobbyDetails")]
        //public async Task Ready(LobbyDetailsViewModel viewModel)
        //{
        //    await _mediator.Send(new UpdatePlayerReadyCommand(viewModel.Game.Id, viewModel.Player.Id), CancellationToken.None);
        //}
    }
}
