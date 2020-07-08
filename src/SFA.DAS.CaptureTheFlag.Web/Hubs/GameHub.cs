using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using DAS_Capture_The_Flag.GameHandlers;
using DAS_Capture_The_Flag.MapService;

namespace DAS_Capture_The_Flag.Hubs
{
    public class GameHub : Hub
    {
        private readonly IGameRepository _repository;
        private readonly IMap _map;
        public GameHub(IGameRepository repository, IMap map) 
        {
            _repository = repository;
            _map = map;
        }

        public async Task SoldierClick(Guid gameId, int player, Guid soldierId)
        {
            var game = _repository.Games.FirstOrDefault(g => g.Id == gameId);

            var PlayersTurnHandler = new PlayersTurnHandler();
            var HighlightSoldierHandler = new HighlightSoldierHandler();

            PlayersTurnHandler
                .SetNext(HighlightSoldierHandler);

            PlayersTurnHandler.Handle(new { game, player, soldierId});

            await Clients.Group(gameId.ToString()).SendAsync("UpdateGame");
        }

        public async Task TileClick(Guid gameId, int player, int x, int y)
        {
            var game = _repository.Games.FirstOrDefault(g => g.Id == gameId);

            var PlayersTurnHandler = new PlayersTurnHandler();
            var MoveSoldierHandler = new MoveSoldierHandler(_map);
            var PassPlayersTurnHandler = new PassPlayersTurnHandler();

            PlayersTurnHandler
                .SetNext(MoveSoldierHandler)
                .SetNext(PassPlayersTurnHandler);

            PlayersTurnHandler.Handle(new { game, player, x, y });

            await Clients.All.SendAsync("UpdateGame");
        }

        public async Task UpdatePlayerConnectionId(string id, string playerId)
        {
            var game = _repository.Games.FirstOrDefault(g => g.Id.ToString() == id);

            if (game.Players.PlayerOne.Id.ToString() == playerId)
            {
                game.Players.PlayerOne.ConnectionId = Context.ConnectionId;
            } 
            else if (game.Players.PlayerTwo.Id.ToString() == playerId)
            {
                game.Players.PlayerTwo.ConnectionId = Context.ConnectionId;
            }
            
            await Groups.AddToGroupAsync(Context.ConnectionId, id);
        }

    }    
}
