using System;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using MediatR;

namespace DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame
{
    public class JoinOrCreateGameCommand : IRequest<JoinOrCreateGameResponse>
    {
        public Player Player { get; set; }

        public JoinOrCreateGameCommand(Player player)
        {
            Player = player;
        }
    }
}
