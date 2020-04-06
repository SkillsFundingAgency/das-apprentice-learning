
using System.Collections.Generic;
using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.Application.Repositories.GameRepository
{
    public interface IGameRepository
    {
        public List<Game> Games { get; set; }
    }

}
