using DAS_Capture_The_Flag.Application.Models.GameModels;
using MediatR;
using System;

namespace DAS_Capture_The_Flag.Application.Handlers.UpdatePlayerReady
{
    public class UpdatePlayerReadyCommand : IRequest<Game>
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }

        public UpdatePlayerReadyCommand(Guid gameId, Guid playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
        }
    }
}
