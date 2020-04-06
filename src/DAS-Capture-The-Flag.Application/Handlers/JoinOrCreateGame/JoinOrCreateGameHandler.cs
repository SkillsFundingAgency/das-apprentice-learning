using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame
{
    public class JoinOrCreateGameHandler : IRequestHandler<JoinOrCreateGameCommand, JoinOrCreateGameResponse>
    {
        private readonly IGameRepository _repository;

        public JoinOrCreateGameHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<JoinOrCreateGameResponse> Handle(JoinOrCreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = _repository.Games.FirstOrDefault(g => !g.Setup.PlayersConnected);

            if (game == null)
            {
                 game = new Game();
                _repository.Games.Add(game = new Game());
            }

            game.Setup.AddPlayerToGame(game, request.PlayerId);

            return new JoinOrCreateGameResponse(game); 
        }
    }
}
