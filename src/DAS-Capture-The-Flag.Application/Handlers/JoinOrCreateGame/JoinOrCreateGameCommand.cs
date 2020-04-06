using DAS_Capture_The_Flag.Application.Models.GameModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame
{
    public class JoinOrCreateGameCommand : IRequest<JoinOrCreateGameResponse>
    {
        public Guid PlayerId { get; set; }

        public JoinOrCreateGameCommand(Guid playerId)
        {
            PlayerId = playerId;
        }
    }
}
