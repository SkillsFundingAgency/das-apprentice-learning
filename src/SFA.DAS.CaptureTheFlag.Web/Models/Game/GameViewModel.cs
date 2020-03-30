using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models.Game
{
    public class GameViewModel
    {
        public string PlayerId { get; set; }
        public string Id { get; set; }
        public Game Game { get; set; }
        public GameViewModel(Game game, string playerId)
        {
            Id = game.Id;
            PlayerId = playerId;
            Game = game;

        }
    }
}
