using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models.Game
{

    public interface IGameRepository
    {
        List<Game> Games { get; set; }

        void UpdatePlayerReady(string connectionId);
    }
    public class GameRepository : IGameRepository
    {
        public GameRepository()
        {
          
        }

        public List<Game> Games { get; set; } = new List<Game>();
        
        public void UpdatePlayerReady(string connectionId)
        {
            //var lGames.FirstOrDefault(g => g.Setup.HasPlayer(connectionId)).Setup.Players.Where(p => p.ConnectionId == connectionId).FirstOrDefault();//.Ready = true;

                //Games[0].Setup.Players[1].Ready = true;
        }
    
    }
}
