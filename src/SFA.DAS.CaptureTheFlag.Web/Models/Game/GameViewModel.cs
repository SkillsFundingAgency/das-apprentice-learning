using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.Web.Models.Game
{
    public class GameViewModel
    {
        public string PlayerId { get; set; }
        public Guid Id { get; set; }
        public Application.Models.GameModels.Game Game { get; set; }
        public GameViewModel(Application.Models.GameModels.Game game, string playerId)
        {
            Id = game.Id;
            PlayerId = playerId;
            Game = game;

        }
    }
}
 