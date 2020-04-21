using DAS_Capture_The_Flag.Application.Models.GameModels;
using System;

namespace DAS_Capture_The_Flag.Web.Models.Lobby
{
    public class LobbyViewModel
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        
        public LobbyViewModel(Game game, Guid playerId)
        {
            if (game == null)
            {
                throw new ArgumentException();
            }
            if (game.Id == Guid.Empty)
            {
                throw new ArgumentException("Game not found");
            }
            if (playerId == Guid.Empty)
            {
                throw new ArgumentException("Player id does not exist");
            }

            Id = game.Id;
            PlayerId = playerId;
        }
    }
}
