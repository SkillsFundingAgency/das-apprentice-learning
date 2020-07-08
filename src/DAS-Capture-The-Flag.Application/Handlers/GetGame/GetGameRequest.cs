using DAS_Capture_The_Flag.Application.Models.GameModels;
using MediatR;
using System;

namespace DAS_Capture_The_Flag.Application.Handlers.GetGame
{
    public class GetGameRequest : IRequest<Game>
    {
        public Guid Id { get; set; }

        public GetGameRequest(Guid id)
        {
            Id = id;
        }
    }
}
