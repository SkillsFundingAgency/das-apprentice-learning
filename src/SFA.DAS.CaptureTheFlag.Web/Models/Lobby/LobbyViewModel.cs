using DAS_Capture_The_Flag.Application.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models.Lobby
{
    public class LobbyViewModel
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }

        public LobbyViewModel() { }

        public LobbyViewModel(Game game, Guid playerId)
        {
            Id = game.Id;
            PlayerId = playerId;
        }
    }
}
