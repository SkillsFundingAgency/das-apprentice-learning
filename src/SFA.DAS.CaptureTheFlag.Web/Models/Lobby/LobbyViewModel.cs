using DAS_Capture_The_Flag.Application.Models.GameModels;
using System;

namespace DAS_Capture_The_Flag.Web.Models.Lobby
{
    public class LobbyViewModel
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }

        public LobbyViewModel() { }

        public LobbyViewModel(Application.Models.GameModels.Game game, Guid playerId)
        {
            if (game == null)
            {
                throw new ArgumentException();
            }

            Id = game.Id;
           
            PlayerId = playerId;
        }
    }
}
