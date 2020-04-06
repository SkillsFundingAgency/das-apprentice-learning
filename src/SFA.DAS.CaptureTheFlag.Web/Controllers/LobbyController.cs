using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Handlers.GetGame;
using DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame;
using DAS_Capture_The_Flag.Application.Handlers.UpdatePlayerReady;
using DAS_Capture_The_Flag.Models.Lobby;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DAS_Capture_The_Flag.Controllers
{
    public class LobbyController : Controller
    {
        private IMediator _mediator;

        public LobbyController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("/lobby")]
        public async Task<IActionResult> Index(Guid playerId)
        {
            var response = await _mediator.Send(new JoinOrCreateGameCommand(playerId));

            var viewModel = new LobbyViewModel(response.Game, playerId);

            return View("~/Views/Lobby/Index.cshtml", viewModel);
        }

        [HttpGet("/lobby/refresh")]
        public string Refresh(Guid gameId)
        {
            var game = _mediator.Send(new GetGameRequest(gameId), CancellationToken.None).Result;

            return JsonConvert.SerializeObject(game);
        }

        [HttpGet("/lobby/update")]
        public string Ready(Guid gameId, Guid playerId) 
        { 
            var game = _mediator.Send(new UpdatePlayerReadyCommand(gameId, playerId), CancellationToken.None).Result;
         
            return JsonConvert.SerializeObject(game);
        }
    }
}