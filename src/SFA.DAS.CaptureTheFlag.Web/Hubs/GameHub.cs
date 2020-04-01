using DAS_Capture_The_Flag.Models.Game;
using DAS_Capture_The_Flag.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Hubs
{
    public class GameHub : Hub<IGameClient>
    {
        private IGameRepository _repository;

        public GameHub(IGameRepository repository) 
        {
            _repository = repository;
        }
        public override async Task OnConnectedAsync()
        {
            var repo = _repository;
        }

        public async Task UpdatePlayerConnectionId(string id, string playerId, Game game)
        {
            _repository.Games.FirstOrDefault(g => g.Id == id).Setup.Players.FirstOrDefault(p => p.ConnectionId == playerId).ConnectionId = Context.ConnectionId;
            await Groups.AddToGroupAsync(Context.ConnectionId, id);
        }

        public async Task CanvasClickController(int x, int y, string gameId)
        {
            var contextId = Context.ConnectionId;
            var game = _repository.Games.FirstOrDefault(g => g.Id == gameId);

            var selectedSoldier = game.Data.Soldiers.Where(s => s.Selected == true).FirstOrDefault();

            if (selectedSoldier is null)
            {
                var soldier = game.Data.Soldiers.Where(s => s.xPos == x && s.yPos == y).FirstOrDefault();
                soldier.Selected = !soldier.Selected;
            }
            else
            {
                selectedSoldier.xPos = x;
                selectedSoldier.yPos = y;
                selectedSoldier.Selected = false;
            }
            

            var updatedGame = JsonConvert.SerializeObject(new GameViewModel(game, Context.ConnectionId));
         
           
            await Clients.Group(gameId).UpdateModel(updatedGame);

        }

       
    }

    public interface IGameClient
    {
        Task UpdatePlayerConnectionId(string id, string playerId);
        Task UpdateModel(string updatedGame);
    }
}
