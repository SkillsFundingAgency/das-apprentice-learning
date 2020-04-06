using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Application.Models.GameModels;

namespace DAS_Capture_The_Flag.Application.Repositories.GameRepository
{

   
    public class GameRepository : IGameRepository
    {
        public GameRepository()
        {
          
        }

        public List<Game> Games { get; set; } = new List<Game>();
        
        public List<Game> GetAllGames()
        {
            return Games;
        }
    }

}
