using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.Handlers.UpdatePlayerReady
{
    public class UpdatePlayerReadyHandler : IRequestHandler<UpdatePlayerReadyCommand, Game>
    {
        private readonly IGameRepository _repository;

        public UpdatePlayerReadyHandler(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task<Game> Handle(UpdatePlayerReadyCommand request, CancellationToken cancellationToken)
        {
            var game = _repository.Games.FirstOrDefault(g => g.Id == request.GameId);
            var player = game.Setup.Players.FirstOrDefault(p => p.Id == request.PlayerId);

            player.Ready = true;

            return game;
        }
    }
}
