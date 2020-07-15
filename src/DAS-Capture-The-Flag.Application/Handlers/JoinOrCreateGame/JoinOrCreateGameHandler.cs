using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using MediatR;
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
            var game = await _repository.JoinOrCreateGame(request.Player);
           
            return new JoinOrCreateGameResponse(game); 
        }
    }
}
