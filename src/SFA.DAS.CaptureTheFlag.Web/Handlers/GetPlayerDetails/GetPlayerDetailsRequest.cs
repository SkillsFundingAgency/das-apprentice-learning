using DAS_Capture_The_Flag.Application.Models.GameModels;
using MediatR;
using System;

namespace DAS_Capture_The_Flag.Web.Handlers.GetPlayerDetails
{
    public class GetPlayerDetailsRequest : IRequest<PlayerDetails>
    {
        public Guid Id { get; set; }

        public GetPlayerDetailsRequest(Guid id)
        {
            Id = id;
        }
    }
}
