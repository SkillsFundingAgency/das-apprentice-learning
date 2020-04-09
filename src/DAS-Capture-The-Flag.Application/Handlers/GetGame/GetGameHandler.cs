using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;

namespace DAS_Capture_The_Flag.Application.Handlers.GetGame
{
    public class GetGameHandler : IRequestHandler<GetGameRequest, Game>
    {
        private readonly IGameRepository _repository;

        public GetGameHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<Game> Handle(GetGameRequest request, CancellationToken cancellationToken)
        {
            return _repository.Games.FirstOrDefault(g => g.Id == request.Id);
        }
    }
}
