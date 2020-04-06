using DAS_Capture_The_Flag.Application.Models.GameModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
