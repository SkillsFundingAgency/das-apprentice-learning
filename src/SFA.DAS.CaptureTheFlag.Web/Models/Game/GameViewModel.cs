using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models.Game
{
    public class GameViewModel
    {
        public string PlayerId { get; set; }
        public string GameId { get; set; }

        public GameViewModel(string gameId, string playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
        }
    }
}
