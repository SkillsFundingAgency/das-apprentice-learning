using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models.Game
{

    public interface IGameRepository
    {
        public List<Game> Games { get; set; }
    }

    public class GameRepository : IGameRepository
    {
        public GameRepository()
        {
          
        }

        public List<Game> Games { get; set; } = new List<Game>();
    
    }
}
