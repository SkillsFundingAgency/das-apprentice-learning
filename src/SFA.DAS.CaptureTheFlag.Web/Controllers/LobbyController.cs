using System;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Web.Handlers.GetPlayerDetails;
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
            var playerDetails = await _mediator.Send(new GetPlayerDetailsRequest(playerId));
            var player = new Player(playerId, playerDetails);

            var response = await _mediator.Send(new JoinOrCreateGameCommand(player));

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
    }
}
