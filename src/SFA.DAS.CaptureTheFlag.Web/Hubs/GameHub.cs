
using DAS_Capture_The_Flag.Models.Game;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Hubs
{
    public class GameHub : BaseHub<IGameClient>
    {

        public GameHub(IGameRepository repository) : base(repository)
        {
        }
        public override async Task OnConnectedAsync()
        {
           // var repo = GetAllGames
        }

        public async Task UpdatePlayerConnectionId(string id, string playerId)
        {
            var game = GetGame(id);

            var player = game.Setup.Players.FirstOrDefault(p => p.ConnectionId == playerId); //GetPlayer(game.Setup, Context.ConnectionId);

            player.ConnectionId = Context.ConnectionId;
        }
    }

    public interface IGameClient
    {
       
    }
}
