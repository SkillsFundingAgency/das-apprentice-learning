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
                throw new ArgumentException("Game was not found or created");
            }
            if (game.Id == Guid.Empty)
            {
                throw new ArgumentException("Game could not be joined");
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
