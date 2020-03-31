using DAS_Capture_The_Flag.Models.Game;
using Microsoft.AspNetCore.SignalR;
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
        }
    }

    public interface IGameClient
    {
        Task UpdatePlayerConnectionId(string id, string playerId);
    }
}
