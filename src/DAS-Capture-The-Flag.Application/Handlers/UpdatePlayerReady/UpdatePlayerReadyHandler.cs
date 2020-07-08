using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using MediatR;
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
            var game = await _repository.UpdatePlayerReady(request.GameId, request.PlayerId);
          
            return game;
        }
    }
}
