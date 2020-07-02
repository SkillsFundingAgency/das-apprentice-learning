using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Models.GameModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using DAS_Capture_The_Flag.Data;
using System.Linq;

namespace DAS_Capture_The_Flag.Web.Handlers.GetPlayerDetails
{
    public class GetPlayerDetailsHandler : IRequestHandler<GetPlayerDetailsRequest, PlayerDetails>
    {
        private readonly ApplicationDbContext _db;
        public GetPlayerDetailsHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PlayerDetails> Handle(GetPlayerDetailsRequest request, CancellationToken cancellationToken)
        {
            var user = _db.Users.FirstOrDefault(user => user.Id == request.Id.ToString());

            return new PlayerDetails(user.UserName);
        }
    }
}
