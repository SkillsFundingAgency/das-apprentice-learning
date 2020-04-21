using System;
using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.Web.Models.GameModels
{
    public class GameViewModel
    {
        public Guid PlayerId { get; set; }
        public Guid Id { get; set; }
        public Game Game { get; set; }
        public GameViewModel(Game game, Guid playerId)
        {
            if (game == null)
            {
                throw new ArgumentException();
            }

            if (game.Id == Guid.Empty)
            {
                throw new ArgumentException("Game was not found");
            }

            Id = game.Id;
            PlayerId = playerId;
            Game = game;

        }
    }
}
 